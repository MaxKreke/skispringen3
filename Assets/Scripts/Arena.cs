using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public int waveCount = 1;

    public void StartWave()
    {
        if (waveCount > 0)
        {
            foreach(Transform t in gameObject.transform)
            {
                Spawner spawner = t.gameObject.GetComponent<Spawner>();
                if(spawner!=null)spawner.Spawn();
            }
            waveCount = 0;
        }
    }
}
