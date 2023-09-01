using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manaanzeige : MonoBehaviour
{
    public float Mana = 100;
    public Texture whiteChaos;
    public Texture blueChaos;
    private RawImage myTexture;

    void Start()
    {
        myTexture = GetComponent<RawImage>();
    }

    void Update()
    {

        GetComponent<RectTransform>().anchoredPosition = new Vector2(Mana, GetComponent<RectTransform>().anchoredPosition.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(Mana * 2, 40);
        if(full())myTexture.texture = whiteChaos;
        else
        {
            myTexture.texture = blueChaos;
            Mana += .01f;
        }

    }

    public bool full()
    {
        if (Mana >= 100) return true;
        return false;
    }
}
