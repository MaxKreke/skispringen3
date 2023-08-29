using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int animationFrames = 0;
    private int animationSpeed = 18;
    private Vector2 dif;
    private float slashWidth = 2f;

    void Start()
    {
        
    }


    void Update()
    {
        if (animationFrames != 0)
        {
            transform.localPosition += new Vector3(dif.x, dif.y, 0)/animationSpeed;
            animationFrames--;
        }
        else if (Input.GetMouseButton(0))
        {
            RandomUnitVector();
            animationFrames = Mathf.RoundToInt(slashWidth * animationSpeed);
        }
    }

    public void RandomUnitVector()
    {
        float randomInner = Random.Range(0f, 2*Mathf.PI);
        float randomOuter = Random.Range(0f, 2*Mathf.PI);
        Vector2 focus = Vector2.Scale(new Vector2(Mathf.Cos(randomInner), Mathf.Sin(randomInner)), new Vector2(.09f, .05f));
        Vector2 pos = Vector2.Scale(new Vector2(Mathf.Cos(randomOuter), Mathf.Sin(randomOuter)), new Vector2(2.8f, 1.4f));
        dif = focus-pos;
        float rot = -Vector2.Angle(dif, Vector2.right);
        if (dif.y > 0) rot = -rot;
        transform.localEulerAngles = new Vector3(0, 0, rot);
        transform.localPosition = new Vector3(pos.x, pos.y, 1.2f);
        Debug.Log(focus);
    }

}
