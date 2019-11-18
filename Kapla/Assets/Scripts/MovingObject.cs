using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
#pragma warning disable 0649
    [Header("MOVEMENT CONFIGURATION")]
    [SerializeField] float movementSpeed=3;
    [SerializeField] int rotationAngle = 90;
    [SerializeField] float rotationSpeed = 1;
#pragma warning restore 0649

    [Header("SCRIPT INFORMATIONS")]
    public GameObject currentPiece;
    public bool canDrop;
    public Rigidbody currentRigidbody;

    Camera mainCamera;
    RaycastHit hit;
    bool rotating;
    protected Quaternion rotationBefore;
    protected Quaternion rotationAfter;
    float rotationTime = 0;
    float currentRotationSpeed;

    private void Start()
    {
        mainCamera = Camera.main;
        currentRotationSpeed = rotationSpeed;
        canDrop = true;
    }

    private void Update()
    {
        if (!GameManager.instance.defeat)
        {
            if (currentPiece)
            {
                float horizontalAxis = Input.GetAxis("Horizontal");
                float verticalAxis = Input.GetAxis("Vertical");
                Vector3 right = transform.InverseTransformDirection(mainCamera.transform.right);
                right.Normalize();
                Vector3 desiredMoveDirection;
                if (currentPiece.transform.position.y > 0 || currentPiece.transform.position.y + verticalAxis > 0)
                {
                    desiredMoveDirection = Vector3.up * verticalAxis + right * horizontalAxis;
                }
                else
                {
                    desiredMoveDirection = right * horizontalAxis;
                }
                if(currentRigidbody.SweepTest(desiredMoveDirection, out hit))
                {
                    if(hit.distance > 0.1f)
                        currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime, Space.World);
                }else
                    currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime, Space.World);
                if (Input.GetButtonDown("Drop") && canDrop && !rotating)
                {
                    StartCoroutine(DropPiece());
                }
                if (Input.GetButtonDown("RotX") && !rotating)
                {
                    Rotate("RotX");
                }
                if (Input.GetButtonDown("RotY") && !rotating)
                {
                    Rotate("RotY");
                }
                if (Input.GetButtonDown("RotZ") && !rotating)
                {
                    Rotate("RotZ");
                }
                if (rotating)
                {
                    rotationTime += Time.deltaTime * currentRotationSpeed;
                    currentPiece.transform.rotation = Quaternion.Slerp(rotationBefore, rotationAfter, rotationTime);
                    if (rotationTime >= 1)
                    {
                        rotating = false;
                        currentRotationSpeed = rotationSpeed;
                    }
                }
            }
        }
    }

    void Rotate(string axis)
    {
        rotating = true;
        rotationTime = 0;
        rotationBefore = currentPiece.transform.rotation;
        Vector3 axisVec = Vector3.zero;
        switch (axis)
        {
            case "RotX":
                axisVec = Vector3.right;
                break;
            case "RotY":
                axisVec = Vector3.up;
                break;
            case "RotZ":
                axisVec = Vector3.forward;
                break;
            default:
                break;
        }
        rotationAfter = Quaternion.AngleAxis(rotationAngle, axisVec) * rotationBefore;
    }

    public IEnumerator DropPiece()
    {
        GameObject stockPiece = currentPiece;
        currentPiece.GetComponent<Piece>().Drop();
        currentRigidbody = null;
        GameManager.instance.ChangePlayer();
        yield return new WaitForSeconds(1);
        GameManager.instance.AllPieces.Add(stockPiece);
        GameManager.instance.InstantiateNewPiece();
    }
}
