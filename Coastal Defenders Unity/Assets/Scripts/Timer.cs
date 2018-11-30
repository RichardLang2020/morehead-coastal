using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int timeLeft;
    public Text countdownText;
    public string navToScene;
    public bool startTimer;
    public static bool endgame;
    public static bool stopTimer;
    // Use this for initialization
    void Start()
    {
        stopTimer = false;
        endgame = false;
        startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (startTimer)
        {
            StartCoroutine("LoseTime");
            Time.timeScale = 1;
            startTimer = !startTimer;
        }

        if(stopTimer)
        {
            StopCoroutine("LoseTime");
        }
        //timer in seconds
        //if timer runs to 0, automatically start simulation

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
            endgame = true;
            //SceneManager.LoadScene(navToScene);
        }

        if (timeLeft < 10)
        {
            countdownText.text = ("0:0" + timeLeft);
        }

        else
        {
            countdownText.text = ("0:" + timeLeft);
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}