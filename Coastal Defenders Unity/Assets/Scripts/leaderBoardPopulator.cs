using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderBoardPopulator : MonoBehaviour {
    
    private Text leaderboards;
    private List<ScoreEntry> scoreEntries;
    private string scoreText;
    public static int scorePlace;
    // Use this for initialization

    void Start()
    {
        leaderboards = this.GetComponent<Text>();
        Debug.Log("TEST");
        Debug.Log(leaderboards.text);
        leaderboards.text = "Leaderboard";
        getScores();
    }

    public void getScoresAgain()
    {
        StartCoroutine(getScores());
    }


    IEnumerator getScores()
    {
        scoreEntries = CurrentLeaderboard.GetLeaderboard();
        Debug.Log("Just got scores from CurrentLeaderboard.cs");
        Debug.Log(scoreEntries[0].player_initials);
        string scoretext = "";
        bool setScore = false;
        for (int i = 0; i < scoreEntries.Count; i++)
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
        Debug.Log(scoreEntries.Count);
        Debug.Log("PLACE IN RANK");
        Debug.Log(scorePlace);
        int leaderBoardLength = 10;
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

        return null;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("HERE");
        //Debug.Log(scoreText);
        leaderboards.text = scoreText;
	}
}
