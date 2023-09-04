using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer vp;
    public string scene;

    private void Start()
    {
        vp.loopPointReached += loadNext;
    }

    void loadNext(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(scene);
    }

}