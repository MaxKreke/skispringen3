using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhurtbox : MonoBehaviour
{
    public Movement player;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (player != null)
            {
                player.HP -= 10;
                Knockback(other.gameObject.transform.position);
            }

        }
    }

    private void Knockback(Vector3 point)
    {
        Vector3 push = 500*(new Vector3(transform.position.x - point.x, .1f, transform.position.z - point.z));
        player.ApplyForce(push);
    }
}
