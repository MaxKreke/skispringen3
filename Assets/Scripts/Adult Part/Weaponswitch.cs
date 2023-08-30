using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class Weaponswitch : MonoBehaviour
{
    public int defaultWeapon = 0;
    public GameObject hand;
    public GameObject[] Sword;
    public bool handUnlocked;
    public bool blastUnlocked;

    private void Update()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            SetWeaponActive(false);
            if (!handUnlocked) return;
            Switch(Input.mouseScrollDelta.y);
            SetWeaponActive(true);
        }

    }

    private void Switch(float delta)
    {
        int weaponCount = 2;
        if (blastUnlocked )weaponCount = 3;
        int roundedDelta = Mathf.RoundToInt(delta);
        defaultWeapon += roundedDelta;
        if (defaultWeapon >= weaponCount)
        {
            defaultWeapon = 0;
        }
        if (defaultWeapon < 0)
        {
            defaultWeapon = weaponCount-1;
        }

    }

    private void SetWeaponActive(bool display)
    {
        if (defaultWeapon == 0)
        {
            Sword[0].SetActive(display);
            Sword[1].SetActive(display);
        } else if (defaultWeapon == 1)
        {
            hand.SetActive(display);
        }
            
    }



}
