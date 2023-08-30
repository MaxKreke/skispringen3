using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToCamera : MonoBehaviour
{
    private Camera playerCam;

    void Start()
    {
        playerCam = Camera.main;
    }

    void Update()
    {
        Vector3 other = playerCam.transform.position;
        Vector3 direction = (other - transform.position);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.Rotate(90 * Vector3.right);
    }
}
