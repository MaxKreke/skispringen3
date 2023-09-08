using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Terminal : MonoBehaviour
{
    public GameObject activeLevel;
    public GameObject [] Levels;
    private AudioSource[] ost;


    public static int Day = 1;
    public static bool success;
    public static List<GameObject> friends = new List<GameObject>();
    public static bool handUnlocked = false;
    public static bool blastUnlocked = false;
    public static int hygiene = 5;
    public static int charisma = 5;
    public static int joy = 0;
    public static int tomfoolery = 0;
    public static int fashion = 0;
    public static int empathy = 0;
    public static int will = 0;
    public static int anger = 0;
    public static bool levelCleared = false;
    public static int Money = 10;

    void Start()
    {
        ost = GetComponents<AudioSource>();
        Terminal.levelCleared = false;
        Terminal.ToggleCursor(false);
        Application.targetFrameRate = 120;

        if(Terminal.Day == 4)
        {
            playCredits();
        }
    }

    public void playCredits()
    {
        GameObject fc = GameObject.Find("FriendContainer");
        for(int i = 0; i < Terminal.friends.Count; i++)
        {
            Instantiate(Terminal.friends[i], fc.transform.position + new Vector3((4*i)-5f, 1, 0), Quaternion.identity);
        }
        Debug.Log("credits");
    }

    public void SelectActiveLevel(GameObject level, GameObject player)
    {
        activeLevel = level;

        //Changing spawnpoint
        Level enteredLevel = level.GetComponent<Level>();
        if (enteredLevel != null) Terminal.SetRespawn(enteredLevel.spawnpoint, player);

        //Other levels go
        foreach(GameObject levelNumber in Levels)
        {
            if(level != levelNumber)
            {
                levelNumber.GetComponent<Level>().Woosh();
            }
        }
    }

    public int GetActiveLevel()
    {
        if (activeLevel == Levels[0]) return 1;
        if (activeLevel == Levels[0]) return 0;
        if (activeLevel == Levels[0]) return 0;
        else return 0;
    }

    public static void ToggleCursor(bool cursor)
    {
        Cursor.visible = cursor;
        if(cursor) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

    }

    public static void SetRespawn(Vector3 respawn, GameObject player)
    {
        Movement playerMovement = player.GetComponent<Movement>();
        if (playerMovement != null) {
            playerMovement.respawn = respawn;
        }
    }

    //Display Framerate
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), (1.0f / Time.smoothDeltaTime).ToString());
    }

    public void EndDay()
    {
        SceneManager.LoadScene("Battle Night");
    }

    public void PlaySound(int i)
    {
        for(int j = 0; j < ost.Length; j++)
        {
            ost[j].volume = 0;
        }
        ost[i].volume = 1;
    }

}
