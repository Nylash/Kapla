using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
#pragma warning disable 0649
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
        float xRot = cameraSpeed * Input.GetAxis("CamVertical") * Time.deltaTime;
        float yRot = cameraSpeed * Input.GetAxis("CamHorizontal") * Time.deltaTime;
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

        //https://gamedev.stackexchange.com/questions/136174/im-rotating-an-object-on-two-axes-so-why-does-it-keep-twisting-around-the-thir
    }
}
