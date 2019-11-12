using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] float movementSpeed=3;
    [SerializeField] int rotationAngle = 90;
#pragma warning restore 0649

    public GameObject currentPiece;
    public bool canDrop;

    Camera mainCamera;
    
    private void Start()
    {
        mainCamera = Camera.main;
        canDrop = true;
    }

    private void FixedUpdate()
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
                currentPiece.transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime);
                if (Input.GetButtonDown("Drop") && canDrop)
                {
                    StartCoroutine(DropPiece());
                }
                if (Input.GetButtonDown("RotX"))
                {
                    currentPiece.transform.eulerAngles += new Vector3(rotationAngle, 0, 0);
                }
                if (Input.GetButtonDown("RotY"))
                {
                    currentPiece.transform.eulerAngles += new Vector3(0, rotationAngle, 0);
                }
                if (Input.GetButtonDown("RotZ"))
                {
                    currentPiece.transform.eulerAngles += new Vector3(0, 0, rotationAngle);
                }
            }
        }
    }

    IEnumerator DropPiece()
    {
        GameObject stockPiece = currentPiece;
        currentPiece.GetComponent<Piece>().Drop();
        GameManager.instance.ChangePlayer();
        yield return new WaitForSeconds(1);
        GameManager.instance.AllPieces.Add(stockPiece);
        GameManager.instance.InstantiateNewPiece();
    }
}
