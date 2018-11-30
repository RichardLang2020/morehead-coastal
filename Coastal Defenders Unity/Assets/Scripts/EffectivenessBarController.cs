using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectivenessBarController : MonoBehaviour
{
    public static float barDisplay;
    private float netLand, netHuman, netAnimal;
    public float minX;
    public float maxX;

    private float time;
    public static bool breakStutter;
    public float duration;
    public static int effectCond;

    private float target;
    public RectTransform effBar;
    public Image effBarImage;
    private Color currentCol;
    private Vector2 init;
    public float speed;
    //0 dune
    //1 bulkhead
    //2 oyster
    //3 floodgate
    //4 seagrass
    public SolutionController[] solutions;

    //values go land, human, animal
    public float[] bulkheadScores;// = new float[] { 5, 5, 1 };
    public float[] seagrassScores;// = new float[] { 3, 1, 3 };
    public float[] sandduneScores;// = new float[] { 3, 2, 2 };
    public float[] floodgateScores;// = new float[] { 4, 6, 2 };
    public float[] oysterScores;// = new float[] { 1, 1, 5 };
    // Use this for initialization
    void Awake()
    {
        effectCond = 1;
        effBar = this.GetComponent<RectTransform>();
        breakStutter = false;
    }

    private float returnEffectiveness()
    {
        netLand = solutions[0].count * sandduneScores[0] + solutions[2].count * oysterScores[0] + solutions[1].count * bulkheadScores[0] + solutions[3].count * floodgateScores[0] + solutions[4].count * seagrassScores[0];
        netHuman = solutions[0].count * sandduneScores[1] + solutions[2].count * oysterScores[1] + solutions[1].count * bulkheadScores[1] + solutions[3].count * floodgateScores[1] + solutions[4].count * seagrassScores[1];
        netAnimal = solutions[0].count * sandduneScores[2] + solutions[2].count * oysterScores[2] + solutions[1].count * bulkheadScores[2] + solutions[3].count * floodgateScores[2] + solutions[4].count * seagrassScores[2];
        PlayerPrefs.SetFloat("netLand", netLand);
        PlayerPrefs.SetFloat("netHuman", netHuman);
        PlayerPrefs.SetFloat("netAnimal", netAnimal);
        //Debug.Log("netLand:" + netLand + "\n netHuman:" + netHuman + "\n netAnimal:" + netAnimal);
        return ((.5f * (netLand / 25f)) + (.25f * (netHuman / 25f)) + (.25f * (netAnimal / 25f)));

    }

    // Update is called once per frame
    void Update()
    {
        float diffX = maxX - minX;
        barDisplay = returnEffectiveness();
        Debug.Log("barDisplay: " + barDisplay);

        target = barDisplay * diffX + minX;

        //Debug.Log("Target:" + target);
        if (target >= maxX)
        {
            effBar.localPosition = new Vector2(maxX, effBar.localPosition.y);
        }
        else if (effBar.localPosition.x <= (target - speed / 2) && !breakStutter)
        {
            effBar.localPosition = new Vector2(effBar.localPosition.x + speed, effBar.localPosition.y);
            if(effBar.localPosition.x >= (target - speed /2))
            {
                breakStutter = true;
            }
        }
        else if (effBar.localPosition.x >= (target + speed / 2) && !breakStutter)
        {
            effBar.localPosition = new Vector2(effBar.localPosition.x - speed, effBar.localPosition.y);
            if (effBar.localPosition.x <= (target - speed / 2))
            {
                breakStutter = true;
            }
        }

        if(barDisplay < 0.3)
        {
            time += Time.deltaTime / duration;
            effBarImage.color = Color.Lerp(currentCol, Color.red, time);
            if(effBarImage.color.Equals(Color.red))
            {
                currentCol = Color.red;
                Debug.Log("red");
                effectCond = 1;
                time = 0;
            }

        } else if(barDisplay <0.7)
        {
            time += Time.deltaTime / duration;
            effBarImage.color = Color.Lerp(currentCol, Color.yellow, time);
            if (effBarImage.color.Equals(Color.yellow))
            {
                currentCol = Color.yellow;
                Debug.Log("YELLOW");
                effectCond = 2;
                time = 0;
            }

        } else if(barDisplay <1)
        {
            time += Time.deltaTime / duration;
            effBarImage.color = Color.Lerp(currentCol, Color.green, time);
            if (effBarImage.color.Equals(Color.green))
            {
                currentCol = Color.green;
                Debug.Log("green");
                effectCond = 3;
                time = 0;
            }

        }
    }
}
