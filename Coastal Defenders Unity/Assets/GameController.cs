using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    /* 
     * This script takes and controls the four components on the scene - brief details for each component are listed below.
     * Top Bar - Lists a warning for the incoming hurricane as well as a timer during the main game
     * Upper Section - Starts as a video but transitions into the main game and dynamically changes based on input resources
     * Middle Section - Gives instructions regarding gameplay, and sometimes offers hints to the players. Also shows the amount of coins remaining
     * Lower Section - Allows players to buy / sell resources, grays out buttons if not possible
     */

    public GameObject topBar;
    public GameObject upperSection;
    public GameObject middleSection;
    public GameObject lowerSection;

    /*
     * 1 - Sand Dunes
     * 2 - Oyster Reefs
     * 3 - Bulkheads
     * 4 - Floodgates
     * 5 - Sandgrass
     */
    private int[] resourceNumbers;
    private bool firstChange;
    private GameObject elementHighlights;
    private static int difficulty;

    void Start()
    {
        resourceNumbers = new int[5];
        // Get ready to play the introduction video

        // Confirm that the introduction video has finished, start swapping things into the main game
        firstChange = true;
        elementHighlights = GetChildren(lowerSection)[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScreen()
    {
        SceneManager.LoadScene("game");
    }

    // Returns all immediate children for a given GameObject
    private GameObject[] GetChildren(GameObject g)
    {
        GameObject[] output = new GameObject[g.transform.childCount];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = g.transform.GetChild(i).gameObject;
        }

        return output;
    }

    // Hides all other children of a given GameObject, and only shows the specified child
    private void OnlyShowChild(GameObject section, int childNumber)
    {
        GameObject[] sectionChildren = GetChildren(section);

        if (childNumber >= sectionChildren.Length)
        {
            Debug.Log("You're trying to access a child that doesn't exist!");
        }

        for (int i = 0; i < sectionChildren.Length; i++)
        {
            if (sectionChildren[i].activeInHierarchy)
            {
                sectionChildren[i].SetActive(false);
            }
        }
        sectionChildren[childNumber].SetActive(true);
    }
}
