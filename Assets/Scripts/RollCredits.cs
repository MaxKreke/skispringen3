using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCredits : MonoBehaviour
{

    public int frames = 10000;
    private RectTransform ownRect;

    private void Start()
    {

        ownRect = GetComponent<RectTransform>();
    }
    void Update()
    {
        if(frames > 0)
        {
            ownRect.anchoredPosition+= Vector2.up;
            frames--;
        }
        else
        {
            Debug.LogError("END");
        }

    }
}
