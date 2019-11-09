using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLeaderboard : MonoBehaviour {
    static List<ScoreEntry> leaderboard = new List<ScoreEntry>(10);

    static CurrentLeaderboard() {
        Start();
    }

    static void Start() {
        leaderboard.Add(new ScoreEntry("KC", 2680));
        leaderboard.Add(new ScoreEntry("DP", 2659));
        leaderboard.Add(new ScoreEntry("HI", 2641));
        leaderboard.Add(new ScoreEntry("SR", 2595));
        leaderboard.Add(new ScoreEntry("TR", 2585));
        leaderboard.Add(new ScoreEntry("RL", 2579));
        leaderboard.Add(new ScoreEntry("KD", 2533));
        leaderboard.Add(new ScoreEntry("JN", 2518));
        leaderboard.Add(new ScoreEntry("SV", 2496));
        leaderboard.Add(new ScoreEntry("DD", 2000));
    }
    
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public static bool AddEntry(ScoreEntry se) {
        try {
            leaderboard.Add(se);
            leaderboard.Sort();
            leaderboard.RemoveAt(10);

            return true;
        } catch(Exception ex) {
            Debug.Log(ex.Message);
            return false;
        }
    }

    public static List<ScoreEntry> GetLeaderboard() {
        return leaderboard;
    }
    
    public int insertPlaceNumber(int score) {
        int currentPlace = 11;

        for(int i = 9; i >= 0; i--) {
            if(score <= leaderboard[i].total_score) {
                return currentPlace;
            }

            currentPlace--;
        }

        return currentPlace;
    }
}
