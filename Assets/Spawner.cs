using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private Enemycontainer container;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("EnemyContainer").GetComponent<Enemycontainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject enemy = Instantiate(enemies[getIndex()],transform.position, Quaternion.identity);
        enemy.transform.parent = container.gameObject.transform;

    }

    public int getIndex()
    {
        return Terminal.Day-1;
    }
}
