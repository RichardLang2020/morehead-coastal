using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeoutScript : MonoBehaviour {

    public int timeLeft;

    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        //timer in seconds
        //if timer runs to 0, automatically start simulation

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            
            SceneManager.LoadScene("mainmenu");
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

