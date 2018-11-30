using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScorePlace : MonoBehaviour {

    public Text textScore;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        textScore.text = " <size=30>" + leaderBoardPopulator.scorePlace + ".</size> " + " " + ScoreCalculator.netScore;
    }
}
