using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneralTimer : MonoBehaviour {
    public Text timerText;
    public int duration;
    public string nextScene;
    public bool done;

    // Use this for initialization
    void Start () {
		if(timerText == null) {
            Debug.Log("We don't have a place to display the time!");
        }

        if (duration == 0) {
            Debug.Log("We don't have a duration in seconds!");
        } else if (duration < 0) {
            Debug.Log("The entered time is negative - unfortunately, this timer counts up!");
        }

        if(nextScene == "") {
            Debug.Log("We don't have a scene to load afterwards - once the timer has ended, we'll change the 'done' boolean to true instead");
        }

        done = false;
        MainTimer(timerText, duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Runs the timer and prints it to the timerText
    private void MainTimer(Text timerText, int seconds) {
        int secondsRemaining = seconds;

        if(secondsRemaining >= 0) {
            int currentMinutes = secondsRemaining / 60;
            int currentSeconds = secondsRemaining % 60;

            string minutesString = currentMinutes.ToString();
            string secondsString = currentSeconds.ToString();
            if (currentSeconds < 10) {
                secondsString = '0' + currentSeconds.ToString();
            }
            timerText.text = minutesString + ":" + secondsString;

            secondsRemaining--;
            StartCoroutine(TimeStall(timerText, secondsRemaining, 1));
        } else {
            Debug.Log("Timer finished!");

            if (nextScene != "") {
                SceneManager.LoadScene(nextScene);
            } else {
                done = true;
            }
        }
    }

    IEnumerator TimeStall(Text timerText, int seconds, int stallTime) {
        yield return new WaitForSeconds(stallTime);
        MainTimer(timerText, seconds);
    }
}
