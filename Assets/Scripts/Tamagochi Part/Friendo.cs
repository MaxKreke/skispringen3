using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendo : MonoBehaviour
{
    public string friendoName;

    public int maxFriendship;
    public int currentFriendship;
    public int maxPatience;
    public int currentPatience;

    public string reduceStat;
    public string attack;

    public float[] modifiers;



    public bool TakeDamage(float dmg, int type)
    {
        float modifier = 1;
        if (type <0)
        {
            modifier = 1;
        }
        else
        {
            modifier = modifiers[type];
        }
        Debug.Log(modifier);
        currentFriendship = (int) Mathf.Clamp(Mathf.Round(currentFriendship)+ modifier * dmg, 0.0f, maxFriendship);

        if (currentFriendship >= maxFriendship)
            return true;
        else 
            return false;
    }

    public bool LosePatience(int dmg)
    {


        currentPatience = (int) Mathf.Max(currentPatience -  dmg, 0.0f);

        if (currentPatience <=0)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }


}
