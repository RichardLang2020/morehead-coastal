using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollingText : MonoBehaviour
{
    public float target;
    public float speed;
    private RectTransform leaderboard;
    public bool doneScroll;
    private Vector2 init;

    // Use this for initialization

    void Start()
    {
        doneScroll = false;
        leaderboard = this.GetComponent<RectTransform>();
        init = leaderboard.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(leaderboard.localPosition.x <= target)
        {
            Debug.Log("DONE");
            doneScroll = true;
        }
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