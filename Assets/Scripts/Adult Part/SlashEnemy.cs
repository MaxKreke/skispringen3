using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEnemy : MonoBehaviour
{

    public Sword sword;
    public LayerMask enemyLayer;

    private void Update()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size/1.8f, transform.rotation, enemyLayer);
        List<Enemy> enemies = new List<Enemy>();
        foreach (Collider other in hits)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if(enemy) enemies.Add(enemy);
            }
        }
        sword.hitEnemies(enemies);
    }

}
