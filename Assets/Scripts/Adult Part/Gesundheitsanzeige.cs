using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gesundheitsanzeige : MonoBehaviour
{
    public Movement HP;
    
    void Update()
    {

        GetComponent<RectTransform>().anchoredPosition = new Vector2(HP.HP, GetComponent<RectTransform>().anchoredPosition.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(HP.HP * 2, 40);
    }
}
