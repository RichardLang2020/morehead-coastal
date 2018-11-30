using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInit : MonoBehaviour {

    private SolutionController[] solutionList;
    private PointsController points;
    // Use this for initialization
    void Start ()
    {
        KeyboardController.slideDisable = true;
        Debug.Log("DIFFICULTY");
        Debug.Log(DiffController.levelselect);
        points = GameObject.FindGameObjectWithTag("Points").GetComponent<PointsController>();
        solutionList = this.gameObject.GetComponentsInChildren<SolutionController>();
        switch(DiffController.levelselect)
        {
            case 1:
                points.pointsCount = 230;
                break;

            case 2:
                points.pointsCount = 210;
                break;

            case 3:
                points.pointsCount = 190;
                break;

            default:
                points.pointsCount = 230;
                break;
        }

        /*
        solutionList[0].count = Random.Range(0, 3);
        solutionList[1].count = Random.Range(0, 3);
        solutionList[2].count = Random.Range(0, 2);
        solutionList[3].count = Random.Range(0, 2);
        solutionList[4].count = Random.Range(1, 3);
        solutionList[0].startcount = solutionList[0].count;
        solutionList[1].startcount = solutionList[1].count;
        solutionList[2].startcount = solutionList[2].count;
        solutionList[3].startcount = solutionList[3].count;
        solutionList[4].startcount = solutionList[4].count;
        */

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
