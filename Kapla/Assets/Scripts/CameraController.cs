using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
#pragma warning disable 0649
    [Header("CAMERA CONFIGURATION")]
    [SerializeField] float cameraSpeed = 3;
    [SerializeField] int maxAngle = 80;
    [SerializeField] int minAngle = 10;
#pragma warning restore 0649

    GameObject center;
    Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Start()
    {
        center = transform.parent.gameObject;
    }

    private void LateUpdate()
    {
        float xRot = cameraSpeed * controls.Gameplay.CameraMovementPad.ReadValue<Vector2>().y * Time.deltaTime;
        float yRot = cameraSpeed * controls.Gameplay.CameraMovementPad.ReadValue<Vector2>().x * Time.deltaTime;
        if ((center.transform.localRotation.eulerAngles.x > minAngle) && (center.transform.localRotation.eulerAngles.x < maxAngle))
        {
            center.transform.Rotate(xRot, 0f, 0f, Space.Self);
            center.transform.Rotate(0f, yRot, 0f, Space.World);
        } 
        else if ((center.transform.localRotation.eulerAngles.x + xRot > minAngle) && (center.transform.localRotation.eulerAngles.x + xRot < maxAngle))
        {
            center.transform.Rotate(xRot, 0f, 0f, Space.Self);
            center.transform.Rotate(0f, yRot, 0f, Space.World);
        }
        else
            center.transform.Rotate(0f, yRot, 0f, Space.World);
        if(controls.Gameplay.CameraCanMove.phase == InputActionPhase.Started)
        {
            float xRotMouse = cameraSpeed/2 * controls.Gameplay.CameraMovementMouse.ReadValue<Vector2>().y * Time.deltaTime;
            float yRotMouse = cameraSpeed/2 * controls.Gameplay.CameraMovementMouse.ReadValue<Vector2>().x * Time.deltaTime;
            if ((center.transform.localRotation.eulerAngles.x > minAngle) && (center.transform.localRotation.eulerAngles.x < maxAngle))
            {
                center.transform.Rotate(xRotMouse, 0f, 0f, Space.Self);
                center.transform.Rotate(0f, yRotMouse, 0f, Space.World);
            }
            else if ((center.transform.localRotation.eulerAngles.x + xRotMouse > minAngle) && (center.transform.localRotation.eulerAngles.x + xRotMouse < maxAngle))
            {
                center.transform.Rotate(xRotMouse, 0f, 0f, Space.Self);
                center.transform.Rotate(0f, yRotMouse, 0f, Space.World);
            }
            else
                center.transform.Rotate(0f, yRotMouse, 0f, Space.World);
        }

        //https://gamedev.stackexchange.com/questions/136174/im-rotating-an-object-on-two-axes-so-why-does-it-keep-twisting-around-the-thir
    }
}
