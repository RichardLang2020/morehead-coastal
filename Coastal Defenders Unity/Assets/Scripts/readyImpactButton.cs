using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readyImpactButton : MonoBehaviour {
    private Button button;
	// Use this for initialization
	void Start () {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(readyImpact);
	}

    void readyImpact()
    {
        if (transitionToBar.barInPlace)
        {
            Timer.endgame = true;
            Timer.stopTimer = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
