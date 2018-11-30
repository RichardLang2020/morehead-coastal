using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onVideoEnd : MonoBehaviour {

    public UnityEngine.Video.VideoPlayer videoPlayer;
    public RawImage sprite;
    private bool fadeOut;
    private Color initCol;
    private bool breakLoop;
    private float time;
    public float duration;
    public Timer timer;
    public Text fadeInText;
    private Color initColText;

	// Use this for initialization
	void Start () {
        fadeOut = false;
        breakLoop = true;
        initCol = sprite.color;
        videoPlayer.loopPointReached += EndReached;
        initColText = new Color(1, 1, 1, 0);
	}
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("End reached.");
        fadeOut = true;
    }
    // Update is called once per frame
    void Update () {
        if(fadeOut)
        {

            time += Time.deltaTime / duration;
            fadeInText.color = Color.Lerp(initColText, Color.white, time);
            sprite.color = Color.Lerp(initCol, Color.clear, time);
        }
        //Debug.Log(sprite.color.a);
        if(Mathf.Approximately(sprite.color.a, 0f) && breakLoop)
        {
            fadeOut = false;
            //Debug.Log("TIMER IS TRUE");
            sprite.raycastTarget = false;
            timer.startTimer = true;
            breakLoop = false;
        }
	}
}
