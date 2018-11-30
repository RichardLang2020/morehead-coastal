using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderBoardPopulator : MonoBehaviour {

    public string url = "localhost:4000/leaderboard/allscores";
    private Text leaderboards;
    private ScoreEntry[] scoreEntries;
    private string scoreText;
    public static int scorePlace;
    // Use this for initialization

    void Start()
    {
        leaderboards = this.GetComponent<Text>();
        Debug.Log("TEST");
        Debug.Log(leaderboards.text);
        leaderboards.text = "Leaderboard";
        StartCoroutine(getScores());
    }

    public void getScoresAgain()
    {
        StartCoroutine(getScores());
    }


    IEnumerator getScores()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            scoreEntries = JsonHelper.FromJson<ScoreEntry>(www.text);
            string scoretext = "";
            bool setScore = false;
            for (int i = 0; i < scoreEntries.Length; i++)
            {
                if ((int)ScoreCalculator.netScore > (int)scoreEntries[i].total_score && !setScore)
                {
                    scorePlace = i + 1;
                    break;
                }
                else if (!setScore)
                {
                    scorePlace = i + 2;
                }
            }
            Debug.Log(scoreEntries.Length);
            Debug.Log("PLACE IN RANK");
            Debug.Log(scorePlace);
            int leaderBoardLength = 10;
            if(scoreEntries.Length < 10)
            {
                leaderBoardLength = scoreEntries.Length;
            }
            for (int i = 0; i < leaderBoardLength; i++)
            {
                if (i == leaderBoardLength-1)
                {
                    scoretext += " <size=30>" + (i + 1) + ".</size> " + scoreEntries[i].player_initials + "  " + scoreEntries[i].total_score;
                }
                else
                {
                    scoretext += " <size=30>" + (i + 1) + ".</size> " + scoreEntries[i].player_initials + "  " + scoreEntries[i].total_score + "\n";
                }
                    Debug.Log(i + ": " + scoreEntries[i].player_initials + ": " + scoreEntries[i].total_score);
            }
            Debug.Log("LEADERBOARD");
            Debug.Log(leaderboards.text);
            Debug.Log(scoretext);
            leaderboards.text = scoretext;
            scoreText = scoretext;

        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("HERE");
        //Debug.Log(scoreText);
        leaderboards.text = scoreText;
	}
}
