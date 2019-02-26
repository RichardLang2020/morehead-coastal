using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour {

    public GameObject topBar;
    public GameObject upperSection;
    public GameObject middleSection;
    public GameObject lowerSection;
    public UnityEngine.Video.VideoPlayer hurricanePlayer;
    public RawImage hurricaneImage;

    /*
     * 0 - Sand Dunes
     * 1 - Oyster Reefs
     * 2 - Bulkheads
     * 3 - Floodgates
     * 4 - Sandgrass
     */
    private int[] currentResourceNumbers;

    // Use this for initialization
    void Start () {
        currentResourceNumbers = GameController.GetResourceNumbers();
        // Debugging purposes, manually putting in 1 of each resource
        if(currentResourceNumbers == null) {
            currentResourceNumbers = new int[5] { 1, 1, 1, 1, 1 };
        }
        LoadResources();
        StartCoroutine(playVideo());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadResources() {
        GameObject mainGame = GetChildren(upperSection)[0];

        for (int resourceNumber = 0; resourceNumber < currentResourceNumbers.Length; resourceNumber++) {
            GameObject resourceArray = GetChildren(mainGame)[resourceNumber + 1];
            
            for(int i = 0; i < currentResourceNumbers[resourceNumber]; i++) {
                GameObject desiredResource = GetChildren(resourceArray)[i];

                desiredResource.SetActive(true);
            }
        }
    }

    // Returns all immediate children for a given GameObject
    private GameObject[] GetChildren(GameObject g) {
        GameObject[] output = new GameObject[g.transform.childCount];

        for (int i = 0; i < output.Length; i++) {
            output[i] = g.transform.GetChild(i).gameObject;
        }

        return output;
    }

    IEnumerator playVideo()
    {
        Debug.Log("VIDEO HERE");

        hurricanePlayer.Prepare();

        //Wait until video is prepared
        while (!hurricanePlayer.isPrepared) {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        hurricaneImage.texture = hurricanePlayer.texture;
        hurricaneImage.color = Color.white;
        
        //Play Video
        hurricanePlayer.Play();

        //image.color = new Color(255.0f, 255.0f, 255.0f, 1f);

        Debug.Log("Playing Video");
        while(hurricanePlayer.isPlaying) {
            yield return null;
        }
        
        Debug.Log("Done Playing Video");
        SceneManager.LoadScene("endgame");
    }
}
