using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEnemy : MonoBehaviour
{

    public Sword sword;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //t.finalMessage();
            //Debug.Log("you win!");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
