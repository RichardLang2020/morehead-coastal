using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transitionToBar : MonoBehaviour {

    public Button[] buttons;
    public Text fadeOutText;
    public RectTransform effectiveBar;
    public float speed;
    private bool fadeIn;
    private bool breakLoop;
    private float initX;
    private float time;
    private Color initColor;
    private Color finalColor;
    public static bool barInPlace;
    public float duration;
	// Use this for initialization
	void Start () {
        barInPlace = false;
        time = 0;
        initX = -800;
        breakLoop = true;
        initColor = new Color(1,1,1,1);
        finalColor = new Color(1, 1, 1, 0);
        fadeIn = false;
		for(int i=0; i<buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(fadeInBar);
        }
	}

    void fadeInBar()
    {
         fadeIn = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (fadeIn && effectiveBar.localPosition.x <= 0 && breakLoop) {
            effectiveBar.localPosition = new Vector2(effectiveBar.localPosition.x + speed, effectiveBar.localPosition.y);
        }
        if(fadeIn && breakLoop)
        {
            time += Time.deltaTime / duration;
            fadeOutText.color = Color.Lerp(initColor, finalColor, time);
        }
        if (Mathf.Approximately(fadeOutText.color.a, 0f) && effectiveBar.localPosition.x >= 0 && breakLoop)
        {
            fadeIn = false;
            breakLoop = false;
        }
        //Debug.Log(gameEnd.endGameLoop);
        if (gameEnd.endGameLoop && effectiveBar.localPosition.x >= initX)
        {
            //Debug.Log("HERE");
            effectiveBar.localPosition = new Vector2(effectiveBar.localPosition.x - speed, effectiveBar.localPosition.y);
        }

        if(effectiveBar.localPosition.x >= 0)
        {
            barInPlace = true;
        }
    }
}
