using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float ChaosPower = 1f;
    public bool blast = false;
    public bool isFriendly;
    private float maximalDistanz = 60;
    private int destroyed = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy && isFriendly)
            {
                Debug.Log(isFriendly);
                enemy.Bleed(ChaosPower);
            }
            Splash();
        }
        else if (other.gameObject.tag == "Untagged")
        {
            Splash();
        }
        else if (other.gameObject.tag == "Character")
        {
            Splash();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isFriendly)
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.Bleed(ChaosPower/8.5f);
            }
        }
    }

    private void Update()
    {
        if (destroyed > 0) destroyed--;
        if (destroyed == 0) 
        {

            Destroy(gameObject);
            return;
        }
        gameObject.transform.position += direction;
        if((Camera.main.gameObject.transform.position-gameObject.transform.position).magnitude > maximalDistanz)
        {
            Destroy(gameObject);
        }
    }

    private void Splash() {
        if (!blast)
        {
            Destroy(gameObject);
            return;
        }
        transform.localScale = new Vector3(.5f, .5f, .5f);
        destroyed = 12;
    }
}
