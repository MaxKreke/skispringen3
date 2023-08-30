using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 2;
    public float verticalRotation = 0;
    public float horizontalRotation = 0;
    public GameObject parentAdult;

    private void Update()
    {
        RotateCamera();
        transform.position = parentAdult.transform.position+Vector3.up/2;
    }

    public void RotateCamera()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation -= inputY;
        horizontalRotation += inputX;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);

    }
}
