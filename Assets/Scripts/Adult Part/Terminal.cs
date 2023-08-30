using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public GameObject activeLevel;
    public GameObject [] Levels;

    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Application.targetFrameRate = 120;
    }

    public void SelectActiveLevel(GameObject level)
    {
        activeLevel = level;
        foreach(GameObject levelNumber in Levels)
        {
            if(level != levelNumber)
            {
                levelNumber.GetComponent<Level>().Woosh();
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), (1.0f / Time.smoothDeltaTime).ToString());
    }
}
