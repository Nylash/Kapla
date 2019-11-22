using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingObject : MonoBehaviour
{
#pragma warning disable 0649
    [Header("MOVEMENT CONFIGURATION")]
    [SerializeField] bool altMovementSyst;
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
        //temp to remove unity's debug updater which crashes with new input
        GameObject go = GameObject.Find("[Debug Updater]");
        if (go != null) DestroyImmediate(go);

        mainCamera = Camera.main;
        currentRotationSpeed = rotationSpeed;
        canDrop = true;
    }

    private void Update()
    {
        if (!GameManager.instance.defeat && currentPiece)
        {
            if (!altMovementSyst)
            {
                float horizontalAxis = GameManager.instance.movementDirection.x;
                float verticalAxis = GameManager.instance.movementDirection.y;
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
                if (currentRigidbody.SweepTest(desiredMoveDirection, out hit))
                {
                    if (hit.distance > 0.1f)
                        currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime, Space.World);
                }
                else
                {
                    currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime, Space.World);
                }
            }
            else
            {
                Vector3 desiredMoveDirection = Quaternion.Euler(new Vector3(0, GameManager.instance.cameraAngle, 0)) * 
                    new Vector3(GameManager.instance.movementDirection.x, GameManager.instance.up - GameManager.instance.down, GameManager.instance.movementDirection.y);

                if (currentRigidbody.SweepTest(desiredMoveDirection, out hit))
                {
                    if (hit.distance > 0.1f)
                        currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime, Space.World);
                }
                else
                {
                    currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime, Space.World);
                }
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

    public void Drop()
    {
        if (currentPiece && !GameManager.instance.defeat && canDrop && !rotating)
            StartCoroutine(DropPiece());
    }

    public void RotX()
    {
        if(!rotating && currentPiece && !GameManager.instance.defeat)
            Rotate("RotX");
    }
    public void RotY()
    {
        if (!rotating && currentPiece && !GameManager.instance.defeat)
            Rotate("RotY");
    }
    public void RotZ()
    {
        if (!rotating && currentPiece && !GameManager.instance.defeat)
            Rotate("RotZ");
    }

    public void SwitchMovementSystem()
    {
        altMovementSyst = !altMovementSyst;
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
