using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public GameObject activeLevel;
    public GameObject [] Levels;

    public static int Day = 1;
    public static List<GameObject> friends = new List<GameObject>();
    public static bool handUnlocked = false;
    public static bool blastUnlocked = false;

    public static int hygiene = 0;
    public static int charisma = 0;
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
        Terminal.levelCleared = false;
        Terminal.ToggleCursor(false);
        Application.targetFrameRate = 120;
    }

    public void SelectActiveLevel(GameObject level, GameObject player)
    {
        activeLevel = level;

        //Changing spawnpoint
        Level enteredLevel = level.GetComponent<Level>();
        Movement playerMovement = player.GetComponent<Movement>();
        if (playerMovement != null && enteredLevel != null) {
            playerMovement.respawn = enteredLevel.spawnpoint;
        }

        //Other levels go
        foreach(GameObject levelNumber in Levels)
        {
            if(level != levelNumber)
            {
                levelNumber.GetComponent<Level>().Woosh();
            }
        }
    }

    public static void ToggleCursor(bool cursor)
    {
        Cursor.visible = cursor;
        if(cursor) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

    }

    //Display Framerate
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), (1.0f / Time.smoothDeltaTime).ToString());
    }

    public void EndDay()
    {
        Debug.LogError("Day is End");
    }

}
