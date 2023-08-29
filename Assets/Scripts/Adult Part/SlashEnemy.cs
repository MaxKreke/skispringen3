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
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            sword.hitEnemy(enemy);
        }

    }

}
