using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardKey : MonoBehaviour {

    public string character;
    public Button but;


	// Use this for initialization
	void Awake () {
        this.GetComponentInChildren<Text>().text = character;
        but = (Button) this.GetComponent("Button");
        //Debug.Log(this.GetComponent<Button>());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
