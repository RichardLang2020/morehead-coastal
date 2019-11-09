using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour {

    private KeyboardKey[] keys;
    private string output;
    public Button slideButton;
    public static bool slideDisable;
    public Text initials;
    private RectTransform trans;
    private bool slide;
    public ScoreCalculator scores;
    public leaderBoardPopulator scoreboard;

	// Use this for initialization
	void Start () {
        scoreboard = new leaderBoardPopulator();
        slideButton.enabled = slideDisable;
        slide = true;
        trans = this.GetComponent<RectTransform>();
        output = "";
        keys = this.GetComponentsInChildren<KeyboardKey>();
        //Debug.Log(keys[0].but);
        slideButton.onClick.AddListener(setSlide);
        for(int i=0; i<keys.Length; i++)
        {
            //Debug.Log(keys[i].character);
            string tempStr = keys[i].character;
            keys[i].but.onClick.AddListener(() => { onClickOutput(tempStr); });
            //Debug.Log(keys[i].character);
        }
	}

    void setSlide()
    {
        slide = !slide;
    }

    void onClickOutput(string val)
    {
        Debug.Log(output.Length+1);
        if(val.Equals("Back"))
        {
            output = output.Substring(0, output.Length - 1);
        } else if(val.Equals("Enter"))
        {
          int[] score_vals = scores.getScores();
            Debug.Log(score_vals);
            Upload(output, score_vals[0], score_vals[1], score_vals[2], score_vals[3]);
        } else if((output.Length+1) <= 2)
        {
            output += val;
        }
        Debug.Log(output);
        initials.text = output;
    }
    IEnumerator Upload(string init, int total_score, int land_saved_score, int human_protection_score, int animal_protection_score)
    {
        ScoreEntry se = new ScoreEntry(init, total_score);
        bool entrySuccess = CurrentLeaderboard.AddEntry(se);
        
        Debug.Log("Form upload complete!");
        // scoreboard.getScoresAgain();
        slide = !slide;
        slideDisable = false;
        slideButton.enabled = slideDisable;
        initials.text = "";
        output = "";

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (slide && trans.localPosition.y >= -840)
        {
            trans.localPosition = new Vector2(0, trans.localPosition.y - 20);
        }
        else if (!slide && trans.localPosition.y <= -90)
        {
            trans.localPosition = new Vector2(0, trans.localPosition.y + 20);

        }
    }
}
