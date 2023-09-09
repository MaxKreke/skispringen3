using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallContainer : MonoBehaviour
{
    public GameObject enemyContainer;
    private bool battle;
    private Terminal terminal;

    void Start()
    {
        battle = false;
        Activate(false);
        terminal = GameObject.Find("Terminal").GetComponent<Terminal>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyContainer.transform.childCount != 0)
        {
            battle = true;
            Activate(true);
            terminal.CombatMusic(true);
        }
        else
        {
            if (battle)
            {
                battle = false;
                Activate(false);
                terminal.CombatMusic(false);
            }
        }

    }

    private void Activate(bool active)
    {
        foreach(Transform t in transform)
        {
            t.gameObject.SetActive(active);
        }
    }
}
