using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;


    /// <summary>
    /// Hier sind die friend Prefabs
    /// </summary>
    public GameObject friendPrefab;
    public GameObject[] friends;


    public BattleState state;

    Friendo friend;
    Tamagochi tama;

    public Text dialogueText;
    public BattleHUD friendHUD;
    public GameObject buttons;

    string[] possibleStats = new string[]{"hygiene", "charisma", "joy", "tomfoolery", "will", "anger"};

    // Start is called before the first frame update
    void Start()
    {
        Terminal.ToggleCursor(true);
        Application.targetFrameRate = 120;
        ChooseRandomOpponent();
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    void ChooseRandomOpponent()
    {
        int rnd = Random.Range(0, 2);
        int index = rnd+2*(Terminal.Day-1);
        friendPrefab = friends[index];
    }

    IEnumerator SetupBattle()
    {

        //Instantiate alles 
        GameObject playerGO = Instantiate(playerPrefab);
        tama = playerGO.GetComponent<Tamagochi>();

        /// 
        /// Hier werden die friend Prefabs geladen
        /// 
        GameObject friendGO = Instantiate(friendPrefab);
        friend = friendGO.GetComponent<Friendo>();        

        dialogueText.text = "You approach " + friend.friendoName + ". Try and make a friend!!";
        friendHUD.SetHUD(friend);

        yield return new WaitUntil(WaitOrClick);


        //fashion check
        if(tama.fashion > 5)
        {
            dialogueText.text = "Your fashion makes a good first impression " + friend.friendoName + " likes that!";
            bool isdead = friend.TakeDamage(20 + 2* (tama.fashion - 5), -1);
            friendHUD.SetFriendship(friend.currentFriendship, friend.maxFriendship);
            yield return new WaitUntil(WaitOrClick);
        }

        //empathy check
        for (int i = 0; i < 3; i++)
        {
            Image test = buttons.transform.GetChild(i).GetComponent<Image>();
            float saturation = Mathf.Max(tama.empathy - 5, 0.0f) * 0.1f;
            float hue = (friend.modifiers[i] + 1) * 40 /360;
            test.color = Color.HSVToRGB(hue, saturation, 1.0f);
        }

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "What is your move?";
        buttons.SetActive(true);
    }

    IEnumerator PlayerAction(int type)
    {

        //attacks
        buttons.SetActive(false);
        
        int stat = 0;
        float mod = 10;
        switch (type)
        {
            case 0:
                stat = tama.charisma;
                dialogueText.text = "You try to compliment " + friend.friendoName;
                mod = friend.modifiers[0];
                break;
            case 1:
                stat = tama.tomfoolery;
                dialogueText.text = "You try to make a joke";
                mod = friend.modifiers[1];
                break;
            case 2:
                stat = tama.anger;
                dialogueText.text = "You provoke " + friend.friendoName ;
                mod = friend.modifiers[2];
                break;
        }
        
        int damage = 15 + 2 * stat;

        CheckEffectiveness(mod);


        //Will check, crit chance
        int crit = Random.Range(0,15);
        if (tama.will > crit)
        {
            damage *= 2;
            dialogueText.text += "\nYour will makes this move twice as effective!!!" ;
        }
        


        bool isdead = friend.TakeDamage(damage, type);
        friendHUD.SetFriendship(friend.currentFriendship, friend.maxFriendship);

        if (isdead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        

        yield return new WaitUntil(WaitOrClick);

        if (!isdead)
        {
            int smelly = 0;
            if (tama.hygiene < 5)
            {
                smelly = (tama.hygiene - 5) *2;
                dialogueText.text = "You smell! " + friend.friendoName + " does not like that.";
            }
            else if (tama.hygiene > 10)
            {
                smelly = (tama.hygiene -10) * 4;
                dialogueText.text = "You smell .... good! " + friend.friendoName + " likes this alot.";
            }
            if (smelly != 0)
            {
                isdead = friend.TakeDamage(smelly, -1);
                friendHUD.SetFriendship(friend.currentFriendship, friend.maxFriendship);

                yield return new WaitUntil(WaitOrClick);
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
    }


    // Hier endet das Battle und eine neue Szene beginnt
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You and " + friend.friendoName + " are now friends! :)";
            Terminal.friends.Add(friendPrefab);

        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = friend.friendoName + " is fed up with you and goes home...  :()";
        }
        Terminal.Day++;
        if(Terminal.Day < 4)SceneManager.LoadScene("Day");
        else SceneManager.LoadScene("Endgame");
    }

    IEnumerator EnemyTurn()
    {
        string reduceStat = friend.reduceStat;
        if (reduceStat == "random")
        {
            reduceStat = possibleStats[Random.Range(0,6)];
        }
        dialogueText.text = friend.friendoName + " " + friend.attack + "!\nYour " + reduceStat + " value fell! ";
        ReduceStat(reduceStat);

        yield return new WaitUntil(WaitOrClick);

        dialogueText.text = friend.friendoName + " loses patience with you.";
        bool patienceGone = friend.LosePatience(20 - tama.joy);
        friendHUD.SetPatience(friend.currentPatience, friend.maxPatience);

        yield return new WaitUntil(WaitOrClick);

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
            case "will":
                if (tama.will == 0)
                { dialogueText.text += " ......... But it's already at 0";}
                else 
                {tama.will -=1;}
                break;
            case "hygiene":
                if (tama.hygiene == 0)
                { dialogueText.text += " ......... But it's already at 0";}
                else 
                {tama.hygiene -=1;}
                break;
            case "charisma":
                if (tama.charisma == 0)
                { dialogueText.text += " ......... But it's already at 0";}
                else 
                {tama.charisma -=1;}
                break;
            case "joy":
                if (tama.joy == 0)
                { dialogueText.text += " ......... But it's already at 0";}
                else 
                {tama.joy -=1;}
                break;
            case "tomfoolery":
                if (tama.tomfoolery == 0)
                { dialogueText.text += " ......... But it's already at 0";}
                else 
                {tama.tomfoolery -=1;}
                break;
            case "anger":
                if (tama.anger == 0)
                { dialogueText.text += " ......... But it's already at 0";}
                else 
                {tama.fashion -=1;}
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

    bool WaitOrClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }

    public void CheckEffectiveness(float mod)
    {
        if (mod < -1 || mod > 2)
        {
            return;
        }
        

        if (mod >= 1.5)
        {
            dialogueText.text += ". " + friend.friendoName + " likes that a lot!!";
        }
        else if (mod <= -0.25f)
        {
            dialogueText.text += ". " + friend.friendoName + " hates that a lot!!";
        }
        else if (mod <= 0.5f && mod > -0.25f)
        {
            dialogueText.text += ". " + friend.friendoName + " does not like that.";
        }
        else 
        {
            dialogueText.text += ". " + friend.friendoName + " likes that.";
        }

    }

}
