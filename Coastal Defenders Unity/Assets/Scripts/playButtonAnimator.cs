using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonAnimator : MonoBehaviour {

    private RectTransform trans;
    public float speed;
    public float scale;
    private float scaletracker;
    private float scalex;
	// Use this for initialization
	void Start () {
        trans = this.GetComponent<RectTransform>();
        scalex = trans.localScale.x;
        scaletracker = scale;
	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(trans.localScale);
        if (trans.localScale.x < scaletracker)
        {
            trans.localScale += new Vector3(speed, speed, 0);
            if (trans.localScale.x >= scaletracker)
            {
                scaletracker = scalex;
            }
        }
        else
        {
            trans.localScale -= new Vector3(speed, speed, 0);
            if (trans.localScale.x <= scaletracker)
            {
                scaletracker = scale;
            }
        }
    }
}
