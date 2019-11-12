using System.Collections;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] float movementSpeed=3;
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
            }
        }
    }

    IEnumerator DropPiece()
    {
        currentPiece.GetComponent<Piece>().Drop();
        GameManager.instance.ChangePlayer();
        yield return new WaitForSeconds(1);
        GameManager.instance.InstantiateNewPiece();
    }
}
