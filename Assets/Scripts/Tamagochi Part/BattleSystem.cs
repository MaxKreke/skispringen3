using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject friendPrefab;

    public BattleState state;

    Friendo friend;
    Tamagochi tama;

    public Text dialogueText;
    public BattleHUD friendHUD;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab);
        tama = playerGO.GetComponent<Tamagochi>();
        GameObject friendGO = Instantiate(friendPrefab);
        friend = friendGO.GetComponent<Friendo>();        

        dialogueText.text = "Du sieht " + friend.friendoName + ". Versuche dich anzufreunden!!";
        friendHUD.SetHUD(friend);

        yield return new WaitForSeconds(3f);

        if(tama.fashion > 10)
        {
            dialogueText.text = "Durch hinterlässt einen guten ersten Eindruck. " + friend.friendoName + " ist leichter anzufreunden!";
            bool isdead = friend.TakeDamage(35, -1);
            friendHUD.SetFriendship(friend.currentFriendship, friend.maxFriendship);
            yield return new WaitForSeconds(3f);
        }

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Was wirst du tun?";
        buttons.SetActive(true);
    }

    IEnumerator PlayerAction(int type)
    {
        buttons.SetActive(false);
        
        int stat = 0;
        switch (type)
        {
            case 0:
                stat = tama.charisma;
                dialogueText.text = "Du versuchst " + friend.friendoName + " zu schmeicheln";
                break;
            case 1:
                stat = tama.tomfoolery;
                dialogueText.text = "Du machst einen Witz";
                break;
            case 2:
                stat = tama.anger;
                dialogueText.text = "Du provozierst " + friend.friendoName ;
                break;
        }
        
        int damage = 15 + 2 * stat;

        int crit = Random.Range(0,15);
        if (tama.will > crit)
        {
            damage *= 2;
            dialogueText.text += "\nDurch deinen starken Willen ist es sehr effektiv" ;
        }
        


        bool isdead = friend.TakeDamage(damage, type);
        friendHUD.SetFriendship(friend.currentFriendship, friend.maxFriendship);

        if (isdead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        

        yield return new WaitForSeconds(3f);

        int smelly = 0;
        if (tama.hygiene < 5)
        {
            smelly = (tama.hygiene - 5) *2;
            dialogueText.text = "Du riechst! " + friend.friendoName + " mag das gar nicht.";
        }
        else if (tama.hygiene > 10)
        {
            smelly = (tama.hygiene -10) * 4;
            dialogueText.text = "Du riechst .... gut! " + friend.friendoName + " mag das sehr.";
        }
        if (smelly != 0)
        {
            isdead = friend.TakeDamage(smelly, -1);
            friendHUD.SetFriendship(friend.currentFriendship, friend.maxFriendship);

            yield return new WaitForSeconds(3f);
        }



        if (isdead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }


    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Du und " + friend.friendoName + " seid jetzt Freunde!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = friend.friendoName + " hat die Schnauze voll von dir und geht nach Hause...";
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = friend.friendoName + " " + friend.attack + "!\nDein " + friend.reduceStat + "-Wert sinkt";
        ReduceStat(friend.reduceStat);

        yield return new WaitForSeconds(2f);

        dialogueText.text = friend.friendoName + " verliert ein wenig die Geduld.";
        bool patienceGone = friend.LosePatience(20 - tama.joy);
        friendHUD.SetPatience(friend.currentPatience, friend.maxPatience);

        yield return new WaitForSeconds(2f);

        if (patienceGone)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        

    }

    public void ReduceStat(string stat)
    {
        switch (stat)
        {
            case "Will":
                if (tama.will == 0)
                {
                    dialogueText.text += " ......... Aber der ist schon 0";
                }
                else 
                {
                    tama.will -=1;
                }
                break;
            default:
                break;
        }
    }

    public void onButtonClick(int type)
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAction(type));
    }

}
