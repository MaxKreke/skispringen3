using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public GameObject activeLevel;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;

    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Application.targetFrameRate = 120;
    }
}
