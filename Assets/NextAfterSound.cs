using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextAfterSound : MonoBehaviour
{

    public AudioSource al;

    // Update is called once per frame
    void Update()
    {
        if(!al.isPlaying) SceneManager.LoadScene("Tutorial");
    }
}
