using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text netScoreText;
    public RectTransform humanPBar;
    public RectTransform propertyPBar;
    public RectTransform ecoPBar;
    public int[] defenseThresholds_1;
    public int[] defenseThresholds_2;
    public int[] defenseThresholds_3;
    public RawImage humanBar;
    public RawImage propertyBar;
    public RawImage ecosystemBar;
    public static int netScore;
    private int netLandScore;
    private int netAnimalScore;
    private int netHumanScore;

    // Use this for initialization
    void Awake()
    {
        netLandScore = Mathf.RoundToInt(620f * Mathf.Log10(PlayerPrefs.GetFloat("netLand") + 1));
        netAnimalScore = Mathf.RoundToInt(620 * Mathf.Log10(PlayerPrefs.GetFloat("netAnimal") + 1));
        netHumanScore = Mathf.RoundToInt(620f * Mathf.Log10(PlayerPrefs.GetFloat("netHuman") + 1));
        netScore = netLandScore + netHumanScore + netAnimalScore;
        PlayerPrefs.SetFloat("netScore", netScore);
        netScoreText.text = Mathf.RoundToInt(netScore).ToString();
        float humanpercent = 0;
        float landpercent = 0;
        float animalpercent = 0;
        if(DiffController.levelselect == 1)
        {
            humanpercent = (PlayerPrefs.GetFloat("netHuman") / 20);
            landpercent = (PlayerPrefs.GetFloat("netLand") / 20);
            animalpercent = (PlayerPrefs.GetFloat("netAnimal") / 20);
            humanPBar.offsetMax = new Vector2((float)(-( 207.5 - 315*(PlayerPrefs.GetFloat("netHuman") / 20))), humanPBar.offsetMax.y);
            propertyPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netLand") / 20))), propertyPBar.offsetMax.y);
            ecoPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netAnimal") / 20))), ecoPBar.offsetMax.y);
        } else if(DiffController.levelselect == 2)
        {
            humanpercent = (PlayerPrefs.GetFloat("netHuman") / 30);
            landpercent = (PlayerPrefs.GetFloat("netLand") / 25);
            animalpercent = (PlayerPrefs.GetFloat("netAnimal") / 25);
            humanPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netHuman") / 30))), humanPBar.offsetMax.y);
            propertyPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netLand") / 25))), propertyPBar.offsetMax.y);
            ecoPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netAnimal") / 25))), ecoPBar.offsetMax.y);

        } else if(DiffController.levelselect == 3)
        {
            humanpercent = (PlayerPrefs.GetFloat("netHuman") / 15);
            landpercent = (PlayerPrefs.GetFloat("netLand") / 35);
            animalpercent = (PlayerPrefs.GetFloat("netAnimal") / 25);
            humanPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netHuman") / 15))), humanPBar.offsetMax.y);
            propertyPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netLand") / 35))), propertyPBar.offsetMax.y);
            ecoPBar.offsetMax = new Vector2((float)(-( 207.5 - 315 * (PlayerPrefs.GetFloat("netAnimal") / 25))), ecoPBar.offsetMax.y);
        }

        if(humanpercent < 0.3)
        {
            humanBar.color = Color.red;
        } else if(humanpercent < 0.7)
        {
            humanBar.color = Color.yellow;
        } else
        {
            humanBar.color = Color.green;
        }
        if (landpercent < 0.3)
        {
            propertyBar.color = Color.red;
        }
        else if (landpercent < 0.7)
        {
            propertyBar.color = Color.yellow;
        }
        else
        {
            propertyBar.color = Color.green;
        }
        if (animalpercent < 0.3)
        {
            ecosystemBar.color = Color.red;
        }
        else if (animalpercent < 0.7)
        {
            ecosystemBar.color = Color.yellow;
        }
        else
        {
            ecosystemBar.color = Color.green;
        }

        if (-humanPBar.offsetMax.x < -107.5)
        {
            humanPBar.offsetMax = new Vector2((float)-(-107.5), humanPBar.offsetMax.y);
        }
        if (-propertyPBar.offsetMax.x < -107.5)
        {
            propertyPBar.offsetMax = new Vector2((float)-(-107.5), propertyPBar.offsetMax.y);
        }
        if (-ecoPBar.offsetMax.x < -107.5)
        {
            ecoPBar.offsetMax = new Vector2((float)-(-107.5), ecoPBar.offsetMax.y);
        }
        
        Debug.Log("VALUES");
        Debug.Log((PlayerPrefs.GetFloat("netHuman")));
        Debug.Log((PlayerPrefs.GetFloat("netLand")));
        Debug.Log((PlayerPrefs.GetFloat("netAnimal")));
        Debug.Log(humanPBar.offsetMax);
        Debug.Log(propertyPBar.offsetMax);
        Debug.Log(ecoPBar.offsetMax);

        //humanBar.

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int[] getScores()
    {
        int[] val = new int[4];
        val[0] = netScore;
        val[1] = netLandScore;
        val[2] = netAnimalScore;
        val[3] = netHumanScore;
        return val;
    }
}
