using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int tier;
    public Enemycontainer container;

    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("EnemyContainer").GetComponent<Enemycontainer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
