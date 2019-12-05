using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingObject : MonoBehaviour
{
#pragma warning disable 0649
    [Header("MOVEMENT CONFIGURATION")]
    [SerializeField] public bool altMovementSyst;
    [SerializeField] float movementSpeed=3;
    [SerializeField] int rotationAngle = 90;
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] GameObject directionGuidePrefab;
#pragma warning restore 0649

    [Header("SCRIPT INFORMATIONS")]
    public GameObject currentPiece;
    public bool canDrop;
    public Rigidbody currentRigidbody;

    Camera mainCamera;
    RaycastHit hit;
    RaycastHit hitShoulder;
    bool rotating;
    protected Quaternion rotationBefore;
    protected Quaternion rotationAfter;
    float rotationTime = 0;
    float currentRotationSpeed;
    MeshRenderer guideRenderer;
    GameObject directionGuide;
    GameObject guideObject;

    private void Start()
    {
        //temp to remove unity's debug updater which crashes with new input
        GameObject go = GameObject.Find("[Debug Updater]");
        if (go != null) DestroyImmediate(go);

        mainCamera = Camera.main;
        currentRotationSpeed = rotationSpeed;
        canDrop = true;
        directionGuide = Instantiate(directionGuidePrefab);
        guideRenderer = directionGuide.GetComponent<MeshRenderer>();
        guideObject = GameObject.FindGameObjectWithTag("Guide");
    }

    private void Update()
    {
        if (!GameManager.instance.defeat && currentPiece)
        {
            #region OLD MOVEMENT SYSTEM
            //Déplacement relatif à la caméra
            /*float horizontalAxis = GameManager.instance.movementDirection.x;
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
            }*/
            #endregion
            Vector3 desiredMoveDirection = Quaternion.Euler(new Vector3(0, GameManager.instance.cameraAngle, 0)) *
                                new Vector3(GameManager.instance.movementDirection.x, GameManager.instance.up - GameManager.instance.down, GameManager.instance.movementDirection.y);

            if (new Vector3(GameManager.instance.movementDirection.x, 0, GameManager.instance.movementDirection.y) != Vector3.zero)
            {
                guideObject.transform.position = currentPiece.transform.position;
                guideObject.transform.Translate(Quaternion.Euler(new Vector3(0, GameManager.instance.cameraAngle, 0)) *
                new Vector3(GameManager.instance.movementDirection.x, 0, GameManager.instance.movementDirection.y));
                directionGuide.transform.position = currentPiece.transform.position;
                directionGuide.transform.LookAt(guideObject.transform.position);
                guideRenderer.enabled = true;
            }
            else
                guideRenderer.enabled = false;

            if (currentRigidbody.SweepTest(desiredMoveDirection, out hit))
            {
                if (hit.distance > 0.1f)
                    currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime, Space.World);
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

    public void Down()
    {
        if (!GameManager.instance.defeat && currentPiece)
        {
            if (currentRigidbody.SweepTest(-Vector3.up * .5f, out hitShoulder))
            {
                if (hitShoulder.distance > .55f)
                    currentPiece.transform.Translate(-Vector3.up * .5f, Space.World);
                else if (hitShoulder.distance > .1f)
                    currentPiece.transform.Translate(-Vector3.up * (hitShoulder.distance - .05f), Space.World);
            }
            else
                currentPiece.transform.Translate(-Vector3.up * .5f, Space.World);
        }
    }

    public void Up()
    {
        if (!GameManager.instance.defeat && currentPiece)
        {
            if (currentRigidbody.SweepTest(Vector3.up * .5f, out hitShoulder))
            {
                if (hitShoulder.distance > .55f)
                    currentPiece.transform.Translate(Vector3.up * .5f, Space.World);
                else if(hitShoulder.distance > .1f)
                    currentPiece.transform.Translate(Vector3.up * (hitShoulder.distance - .05f), Space.World);
            }
            else
                currentPiece.transform.Translate(Vector3.up * .5f, Space.World);
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
                axisVec = currentPiece.transform.right;
                break;
            case "RotY":
                axisVec = currentPiece.transform.up;
                break;
            case "RotZ":
                axisVec = currentPiece.transform.forward;
                break;
            default:
                break;
        }
        rotationAfter = Quaternion.AngleAxis(rotationAngle, axisVec) * rotationBefore;
    }

    public IEnumerator DropPiece()
    {
        guideRenderer.enabled = false;
        GameManager.instance.dropping = true;
        canDrop = true;
        GameObject stockPiece = currentPiece;
        currentPiece.GetComponent<Piece>().Drop();
        currentRigidbody = null;
        GameManager.instance.ChangePlayer();
        yield return new WaitForSeconds(1);
        GameManager.instance.AllPieces.Add(stockPiece);
        GameManager.instance.InstantiateNewPiece();
    }
}
