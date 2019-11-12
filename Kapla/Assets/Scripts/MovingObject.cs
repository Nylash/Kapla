using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float movementSpeed=3;

    Camera mainCamera;
    
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        Vector3 right = transform.InverseTransformDirection(mainCamera.transform.right);
        right.Normalize();
        Vector3 desiredMoveDirection = Vector3.up * verticalAxis + right * horizontalAxis;
        transform.Translate(desiredMoveDirection * movementSpeed * Time.deltaTime);
    }
}
