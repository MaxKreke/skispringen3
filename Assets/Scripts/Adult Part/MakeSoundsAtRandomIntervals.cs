using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSoundsAtRandomIntervals : MonoBehaviour
{
    public AudioClip[] clips;
    //Bottom 720, top 7920
    private int countdown;



    // Start is called before the first frame update
    void Start()
    {
        countdown = Random.Range(800, 8000);
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown>0)countdown--;
        else
        {
            int randomIndex = Random.Range(0, clips.Length);
            AudioSource.PlayClipAtPoint(clips[randomIndex], transform.position);
            countdown = Random.Range(720, 15120);
        }
    }
}
