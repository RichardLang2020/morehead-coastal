using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour {

    public GameObject topBar;
    public GameObject upperSection;
    public GameObject middleSection;
    public GameObject lowerSection;

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
        LoadResources();
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

}
