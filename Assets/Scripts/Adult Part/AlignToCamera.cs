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
        rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        transform.rotation = rotation;
        transform.Rotate(90 * Vector3.right);
    }
}