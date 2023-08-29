using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCollider : MonoBehaviour
{
    public GameObject Level;
    public Terminal terminal;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("hi :)");
            terminal.SelectActiveLevel(Level);
        }
    }
}
