using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enterScore : MonoBehaviour {

    public Button enterScoreBut;

	// Use this for initialization
	void Start () {
        enterScoreBut = this.GetComponent<Button>();
        enterScoreBut.onClick.AddListener(openKeyboard);
	}
	void openKeyboard()
    {
        System.Diagnostics.Process.Start("osk.exe");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
