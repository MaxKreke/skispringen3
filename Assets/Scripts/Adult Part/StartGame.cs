using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioClip beforeYouLeave;
    public Narrator narrator;
    public bool triggered = false;


    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.gameObject.tag == "Character")
        {
            triggered = true;
            narrator.play(beforeYouLeave);
        }
    }

    private void Update()
    {
        if (!triggered) return;
        if(!narrator.isPlaying())SceneManager.LoadScene("PostTutorial");
    }
}
