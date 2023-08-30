using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animation : MonoBehaviour
{
    public Texture[] sprites;
    [Tooltip("high number = low speed")]
    public int AnimationSpeed;
    private int counter;
    private int initID;
    private RawImage myTexture;

    // Start is called before the first frame update
    void Start()
    {
        initID = 0;
        counter = 0;
        myTexture = GetComponent<RawImage>();
        Debug.Log(myTexture.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == 0) {
            counter = AnimationSpeed;
            Texture currentTex = sprites[incrementInitID()];
            myTexture.texture = currentTex;

        }
        else
        {
            counter--;
        }
    }

    private int incrementInitID()
    {
        initID++;
        if(initID>=sprites.Length)initID = 0;
        return initID;
    }
}
