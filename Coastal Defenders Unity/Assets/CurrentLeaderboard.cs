using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CurrentLeaderboard {
    static List<ScoreEntry> leaderboard = new List<ScoreEntry>(10);

    static CurrentLeaderboard() {

    }

    static void Start() {
        if(leaderboard == null) {
            leaderboard[0].player_initials = "KC";
            leaderboard[0].total_score = 2680;

            leaderboard[1].player_initials = "DP";
            leaderboard[1].total_score = 2659;

            leaderboard[2].player_initials = "HI";
            leaderboard[2].total_score = 2641;

            leaderboard[3].player_initials = "SR";
            leaderboard[3].total_score = 2595;

            leaderboard[4].player_initials = "TR";
            leaderboard[4].total_score = 2585;

            leaderboard[5].player_initials = "RL";
            leaderboard[5].total_score = 2579;

            leaderboard[6].player_initials = "KD";
            leaderboard[6].total_score = 2533;

            leaderboard[7].player_initials = "JN";
            leaderboard[7].total_score = 2518;

            leaderboard[8].player_initials = "SV";
            leaderboard[8].total_score = 2496;

            leaderboard[9].player_initials = "DD";
            leaderboard[9].total_score = 2446;
        }
    }

    static bool AddEntry(ScoreEntry se) {
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

    static List<ScoreEntry> GetLeaderboard() {
        return leaderboard;
    }

    static void Main(String[] args) {
        List<ScoreEntry> test = CurrentLeaderboard.GetLeaderboard();
        foreach(ScoreEntry se in test) {
            Console.WriteLine(se.player_initials + " : " + se.total_score);
        }

        ScoreEntry newEntry = new ScoreEntry();
        newEntry.player_initials = "MM";
        newEntry.total_score = 3000;
        CurrentLeaderboard.AddEntry(newEntry);

        test = CurrentLeaderboard.GetLeaderboard();
        foreach (ScoreEntry se in test)
        {
            Console.WriteLine(se.player_initials + " : " + se.total_score);
        }
    }
}
