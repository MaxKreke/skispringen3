using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Vector3 direction;
    public Vector3 spawnpoint;
    private int steps = 0;

    private void Update()
    {
        if(steps > 0)
        {
            gameObject.transform.position += direction;
            steps--;
        }
    }

    public void Woosh()
    {
        steps = 1000;
    }
}
