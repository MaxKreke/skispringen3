using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 300;

    public void Bleed(float dmg)
    {
        if (HP > 0)
        {
            HP -= Mathf.RoundToInt(dmg);
            Debug.Log($"HP = {HP}");
        }
        if (HP == 0)
        {
            Debug.Log("aa i am ded");
            this.gameObject.SetActive(false);
        }
    }
}
