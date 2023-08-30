using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollider : MonoBehaviour
{
    public GameObject Level;
    public Terminal terminal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            terminal.SelectActiveLevel(Level, other.gameObject);
        }
    }
}
