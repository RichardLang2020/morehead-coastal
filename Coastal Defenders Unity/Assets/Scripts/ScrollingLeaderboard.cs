using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingLeaderboard : MonoBehaviour
{
    public float target;
    public float speed;
    private RectTransform leaderboard;
    private Vector2 init;
    public string url = "localhost:4000/leaderboard/scores";
    public ScoreEntry[] scoreEntries;

    // Use this for initialization

    void Awake()
    {
        StartCoroutine(getScores());
    }

    void Start()
    {
        leaderboard = this.GetComponent<RectTransform>();
        init = leaderboard.localPosition;
    }

    void outputScores()
    {
        for (int i = 0; i < scoreEntries.Length; i++)
        {
            Debug.Log(i + ": " + scoreEntries[i].player_initials + ": " + scoreEntries[i].total_score);
        }
    }

    IEnumerator getScores()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            scoreEntries = JsonHelper.FromJson<ScoreEntry>(www.text);
            string scoretext = "";
            for (int i = 0; i < scoreEntries.Length; i++)
            {
                scoretext += (i + 1) + "." + scoreEntries[i].player_initials + ": " + scoreEntries[i].total_score + "    ";
                Debug.Log(i + ": " + scoreEntries[i].player_initials + ": " + scoreEntries[i].total_score);
            }
            this.GetComponent<Text>().text = scoretext;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (leaderboard.localPosition.x <= target)
        {
            leaderboard.localPosition = init;
        }
        else
        {
            leaderboard.localPosition = new Vector2(leaderboard.localPosition.x + speed, leaderboard.localPosition.y);
        }
    }
}