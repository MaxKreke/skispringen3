using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class Weaponswitch : MonoBehaviour
{
    public int defaultWeapon = 0;
    public GameObject [] hand;
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
        }

    }

    public void Switch(float delta)
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
        SetWeaponActive(true);

    }

    private void SetWeaponActive(bool display)
    {
        if (defaultWeapon == 0)
        {
            Sword[0].SetActive(display);
            Sword[1].SetActive(display);
        } else if (defaultWeapon == 1)
        {
            hand[0].SetActive(display);
            hand[1].SetActive(display);
            if (!display) return;
            animation handimation = hand[1].GetComponent<animation>();
            ChaosPebbleHandGun gun = hand[0].GetComponent<ChaosPebbleHandGun>();
            if (!handimation) return;
            if (!gun) return;
            handimation.AnimationSpeed = 12;
            gun.Blastin(false);
        } else if (defaultWeapon == 2)
        {
            hand[0].SetActive(display);
            hand[1].SetActive(display);
            if (!display) return;
            animation handimation = hand[1].GetComponent<animation>();
            ChaosPebbleHandGun gun = hand[0].GetComponent<ChaosPebbleHandGun>();
            if (!handimation) return;
            if (!gun) return;
            handimation.AnimationSpeed = 1;
            gun.Blastin(true);
        }

            
    }

}
