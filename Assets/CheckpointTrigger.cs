using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public Vector3 spawnposition;
    public Arena arena;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Terminal.SetRespawn(spawnposition, other.gameObject);
            if(arena != null)
            {
                arena.StartWave();
            }
        }
    }
}
