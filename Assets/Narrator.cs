using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void play(AudioClip sound)
    {
        source.clip = sound;
        source.Play();
    }

    public bool isPlaying()
    {
        return source.isPlaying;
    }
}
