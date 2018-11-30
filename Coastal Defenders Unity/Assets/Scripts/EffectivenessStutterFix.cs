using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectivenessStutterFix : MonoBehaviour {

    public Button[] buttons;
	// Use this for initialization
	void Start () {
		for(int i=0; i<buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(stutterFix);
        }
	}

    void stutterFix()
    {
        EffectivenessBarController.breakStutter = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
