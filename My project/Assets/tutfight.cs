using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class tutfight : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject uiVideo;

    public void startcutscene()
    {
        video.gameObject.SetActive(true);
        uiVideo.SetActive(true);
        video.time = 0;
        video.Play();
    }
}
