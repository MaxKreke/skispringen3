using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiAnimation : MonoBehaviour
{
    public Material[] sprites;
    public int AnimationSpeed;
    private int counter;
    private int initID;
    private MeshRenderer mrenderer;

    // Start is called before the first frame update
    void Start()
    {
        initID = 0;
        counter = 0;
        mrenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 0)
        {
            counter = AnimationSpeed;
            Material currentMat = sprites[incrementInitID()];
            mrenderer.material = currentMat;

        }
        else
        {
            counter--;
        }
    }

    private int incrementInitID()
    {
        initID++;
        if (initID >= sprites.Length) initID = 0;
        return initID;
    }

}
