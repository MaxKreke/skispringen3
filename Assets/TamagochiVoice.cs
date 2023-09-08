using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamagochiVoice : MonoBehaviour
{
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        if (Terminal.Day == 1) AudioSource.PlayClipAtPoint(clips[0], transform.position);
        else if (Terminal.Day == 2) AudioSource.PlayClipAtPoint(clips[4], transform.position);
        else if(Terminal.success) AudioSource.PlayClipAtPoint(clips[7], transform.position);
        else AudioSource.PlayClipAtPoint(clips[8], transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnHome()
    {
        if (Terminal.Day == 1) AudioSource.PlayClipAtPoint(clips[2], transform.position);
        else if (Terminal.Day == 2) AudioSource.PlayClipAtPoint(clips[6], transform.position);
        else AudioSource.PlayClipAtPoint(clips[11], transform.position);
    }
}
