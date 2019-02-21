using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


/// <summary>
/// Unity VideoPlayer Script for Unity 5.6 (currently in beta 0b11 as of March 15, 2017)
/// Blog URL: http://justcode.me/unity2d/how-to-play-videos-on-unity-using-new-videoplayer/
/// YouTube Video Link: https://www.youtube.com/watch?v=nGA3jMBDjHk
/// StackOverflow Disscussion: http://stackoverflow.com/questions/41144054/using-new-unity-videoplayer-and-videoclip-api-to-play-video/
/// Code Contiburation: StackOverflow - Programmer
/// </summary>


public class GameIntroController : MonoBehaviour
{

    public RawImage image;
    public string nextScene;

    public UnityEngine.Video.VideoPlayer videoPlayer;
    private VideoSource videoSource;

    // Use this for initialization
    void Awake()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {
        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;

        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;

        //Play Video
        videoPlayer.Play();

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying) {
            yield return null;
        }

        Debug.Log("Done Playing Video");
        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update() {

    }
}