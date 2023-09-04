using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCredits : MonoBehaviour
{

    public int frames = 100;
    private RectTransform ownRect;

    private void Start()
    {

        ownRect = GetComponent<RectTransform>();
    }
    void Update()
    {
        if(frames > 0)
        {
            Debug.Log(frames);
            ownRect.anchoredPosition+= Vector2.up;
            frames--;
        }
        else
        {
            Application.Quit();
        }

    }
}
