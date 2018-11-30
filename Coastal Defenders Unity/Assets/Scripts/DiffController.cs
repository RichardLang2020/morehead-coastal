using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiffController : MonoBehaviour {
    public DiffButton[] difficulties;
    public static int levelselect;
    public string navToScene;
	// Use this for initialization
	void Start () {
		for(int i=0; i<difficulties.Length; i++)
        {
            int tempStr = difficulties[i].level;
            difficulties[i].but.onClick.AddListener(() => { onClickOutput(tempStr); });
        }
	}

    void onClickOutput(int diff)
    {
        Debug.Log(diff);
        levelselect = diff;
        SceneManager.LoadScene("game");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
