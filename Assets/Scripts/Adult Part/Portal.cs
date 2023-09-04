using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 targetPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Terminal.levelCleared = true;
            other.gameObject.transform.position = targetPosition;
            Terminal.SetRespawn(targetPosition, other.gameObject);
        }
    }
}
