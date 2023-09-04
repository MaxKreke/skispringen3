using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallContainer : MonoBehaviour
{
    public GameObject enemyContainer;

    // Update is called once per frame
    void Update()
    {
        Activate(enemyContainer.transform.childCount != 0);
    }

    private void Activate(bool active)
    {
        foreach(Transform t in transform)
        {
            t.gameObject.SetActive(active);
        }
    }
}
