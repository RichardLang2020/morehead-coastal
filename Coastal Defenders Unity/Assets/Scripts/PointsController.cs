using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{

    public int pointsCount;
    private Text pointsText;
    // Use this for initialization
    void Start()
    {
        pointsText = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = pointsCount.ToString();
    }
}
