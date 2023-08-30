using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float ChaosPower = 1f;
    private float maximalDistanz = 60;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.Bleed(ChaosPower);
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Untagged")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Character")
        {
            Debug.Log("Character Hit");
            Destroy(gameObject);
        }


    }

    private void Update()
    {
        gameObject.transform.position += direction;
        if((Camera.main.gameObject.transform.position-gameObject.transform.position).magnitude > maximalDistanz)
        {
            Destroy(gameObject);
        }
    }
}
