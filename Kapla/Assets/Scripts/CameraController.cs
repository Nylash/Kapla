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

    private void Start()
    {
        center = transform.parent.gameObject;
    }

    private void LateUpdate()
    {
        center.transform.eulerAngles = new Vector3(center.transform.eulerAngles.x, center.transform.eulerAngles.y, 0);
        if (!GameManager.instance.dropping)
        {
            float xRot = cameraSpeed * GameManager.instance.cameraMovementPad.y * Time.deltaTime;
            float yRot = cameraSpeed * GameManager.instance.cameraMovementPad.x * Time.deltaTime;
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
            if (GameManager.instance.cameraCanMove)
            {
                float xRotMouse = cameraSpeed / 8 * GameManager.instance.cameraMovementMouse.y * Time.deltaTime;
                float yRotMouse = cameraSpeed / 8 * GameManager.instance.cameraMovementMouse.x * Time.deltaTime;
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
            GameManager.instance.cameraAngle = center.transform.rotation.eulerAngles.y;

            if (xRot == 0 && !GameManager.instance.cameraCanMove)
            {
                if(center.transform.localEulerAngles.x < minAngle)
                    center.transform.localEulerAngles = Vector3.Lerp(center.transform.localEulerAngles, new Vector3(minAngle, center.transform.localEulerAngles.y, 0), Time.deltaTime);
                if(center.transform.localEulerAngles.x > maxAngle)
                    center.transform.localEulerAngles = Vector3.Lerp(center.transform.localEulerAngles, new Vector3(maxAngle, center.transform.localEulerAngles.y, 0), Time.deltaTime);
            }

            //https://gamedev.stackexchange.com/questions/136174/im-rotating-an-object-on-two-axes-so-why-does-it-keep-twisting-around-the-thir
        }
    }
}
