using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class gameEnd : MonoBehaviour {
    public RawImage backdrop;
    public Text text;
    public static bool endGameLoop;
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public VideoClip[] videoClips = new VideoClip[3];
    public VideoClip[] hurricanePath = new VideoClip[3];
    public RawImage hurricaneImage;
    public UnityEngine.Video.VideoPlayer hurricanePlayer;
    public RawImage image;
    private bool breakLoop;
    private float time;
    public float duration;
    private Color initCol;
    // Use this for initialization
    void Start () {
        initCol = backdrop.color;
        endGameLoop = false;
        breakLoop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Timer.endgame)
        {
            Timer.endgame = false;
            endGameLoop = true;
            text.text = "Brace for Impact!";
        }
        if(endGameLoop && breakLoop)
        {
            backdrop.raycastTarget = true;
            time += Time.deltaTime / duration;
            text.color = Color.Lerp(Color.clear, Color.white, time);
            backdrop.color = Color.Lerp(Color.clear, initCol, time);

        }
        if (endGameLoop && Mathf.Approximately(backdrop.color.a, initCol.a) && breakLoop)
        {
            breakLoop = false;
            StartCoroutine(playVideo());
            Debug.Log("STARTING END ANIMATION");
        }
    }

    IEnumerator playVideo()
    {
        Debug.Log("VIDEO HERE");
        if(EffectivenessBarController.barDisplay < 0.3)
        {
            videoPlayer.clip = videoClips[0];
        }
        else if (EffectivenessBarController.barDisplay < 0.7)
        {
            videoPlayer.clip = videoClips[1];
        }
        else if (EffectivenessBarController.barDisplay < 2)
        {
            videoPlayer.clip = videoClips[2];
        }

        if(DiffController.levelselect == 1)
        {
            hurricanePlayer.clip = hurricanePath[0];
        } else if(DiffController.levelselect == 2)
        {
            hurricanePlayer.clip = hurricanePath[1];
        } else if(DiffController.levelselect == 3)
        {
            hurricanePlayer.clip = hurricanePath[2];
        }
        videoPlayer.Prepare();
        hurricanePlayer.Prepare();
        //Disable Play on Awake for both Video and Audio
        //videoPlayer.playOnAwake = false;

        //Wait until video is prepared
        while (!videoPlayer.isPrepared || !hurricanePlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        hurricaneImage.texture = hurricanePlayer.texture;
        image.texture = videoPlayer.texture;
        hurricaneImage.color = Color.white;



        //Play Video
        hurricanePlayer.Play();
        videoPlayer.Play();


        //image.color = new Color(255.0f, 255.0f, 255.0f, 1f);

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying || hurricanePlayer.isPlaying)
        {
            //Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }
        

        Debug.Log("Done Playing Video");
        backdrop.color = initCol;
        SceneManager.LoadScene("endgame");
    }
}
