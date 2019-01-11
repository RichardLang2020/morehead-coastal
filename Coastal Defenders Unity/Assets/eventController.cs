using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class eventController : MonoBehaviour {
    /* 
     * This script takes and controls the three components on the scene - brief details for each scene are listed below.
     * Upper Section - Initially shows information for the hurricane, then gives information for the selected resource
     * Middle Section - Initially gives detailed instructions, then swaps to less details
     * Lower Section - Shows all five possible resources, highlighting the selected one, and also contains the continue button
     */

    public GameObject upperSection;
    public GameObject middleSection;
    public GameObject lowerSection;

    private bool canContinue;
    private GameObject[] sectionArray;
    private List<GameObject> currentlyActive;
    private bool seenNatural;
    private bool seenManMade;
    private bool firstChange;
    private GameObject elementHighlights;
    private static int difficulty;

    void Start () {
        canContinue = false;
        sectionArray = new GameObject[3];
        sectionArray[0] = upperSection;
        sectionArray[1] = middleSection;
        sectionArray[2] = lowerSection;
        currentlyActive = new List<GameObject>();
        seenNatural = false;
        seenManMade = false;
        firstChange = true;
        elementHighlights = GetChildren(lowerSection)[1];
        difficulty = Random.Range(1, 4);
        Debug.Log("We're about to call diff.setup");
        DifficultySetup();
        Debug.Log("We've finished calling diff.setup");

        /*for(int i = 0; i < sectionArray.Length; i++) {
            Debug.Log("Section " + i + ": " + sectionArray[i]);

            GameObject[] sectionChildren = getChildren(sectionArray[i]);

            for(int j = 0; j < sectionChildren.Length; j++) {
                Debug.Log(sectionArray[i] + "has child " + sectionChildren[j] + ", which is currently " + sectionChildren[j].activeInHierarchy);
                if(sectionChildren[j].activeInHierarchy) {
                    currentlyActive.Add(sectionChildren[j]);
                }
            }
        }

        Debug.Log(getChildren(upperSection)[0]);
        Debug.Log(getChildren(upperSection)[0].activeInHierarchy);
        Debug.Log(getChildren(upperSection)[1]);
        Debug.Log(getChildren(upperSection)[1].activeInHierarchy);*/

        //Debug.Log(upperSection[1]);

        /*for(int i = 0; i < currentlyActive.Count; i++) {
            Debug.Log("The GameObject " + currentlyActive[i] + " is currently active!");

            Debug.Log("We're going to try removing that GameObject now - give us a second");
            StartCoroutine(StallTime(1));
            currentlyActive[i].SetActive(false);
            Debug.Log("Did it work?");
            StartCoroutine(StallTime(5));
            Debug.Log("Onwards to the next one!");
        }*/

        /*
        middleSection = canvas.transform.GetChild(2).gameObject;
        
        int childCount = canvas.transform.childCount;
        Debug.Log("The current canvas has " + childCount + "children");
        for (int i = 0; i < childCount; i++) {
            Debug.Log("Child " + i + ": " + canvas.transform.GetChild(i));
        }
        */


    }

    // Update is called once per frame
    void Update () {
		
	}

    // Stalls for a given amount of time
    IEnumerator StallTime(int t) {
        yield return new WaitForSeconds(t);
    }

    public void ShowSandDuneInfo() {
        OnlyShowChild(upperSection, 1);
        OnlyShowChild(elementHighlights, 0);
        if(firstChange) {
            firstChange = false;
            OnlyShowChild(middleSection, 1);
        }
        seenNatural = true;
        if(AbleToContinue()) {
            ActivateContinue();
        }
    }
    public void ShowSeaGrassInfo() {
        OnlyShowChild(upperSection, 2);
        OnlyShowChild(elementHighlights, 1);
        if (firstChange) {
            firstChange = false;
            OnlyShowChild(middleSection, 1);
        }
        seenNatural = true;
        if (AbleToContinue()) {
            ActivateContinue();
        }
    }
    public void ShowOysterReefInfo() {
        OnlyShowChild(upperSection, 3);
        OnlyShowChild(elementHighlights, 2);
        if (firstChange) {
            firstChange = false;
            OnlyShowChild(middleSection, 1);
        }
        seenNatural = true;
        if (AbleToContinue()) {
            ActivateContinue();
        }
    }
    public void ShowFloodgateInfo() {
        OnlyShowChild(upperSection, 4);
        OnlyShowChild(elementHighlights, 3);
        if (firstChange) {
            firstChange = false;
            OnlyShowChild(middleSection, 1);
        }
        seenManMade = true;
        if (AbleToContinue()) {
            ActivateContinue();
        }
    }
    public void ShowBulkheadInfo() {
        OnlyShowChild(upperSection, 5);
        OnlyShowChild(elementHighlights, 4);
        if (firstChange) {
            firstChange = false;
            OnlyShowChild(middleSection, 1);
        }
        seenManMade = true;
        if (AbleToContinue()) {
            ActivateContinue();
        }
    }

    public void NextScreen() {
        SceneManager.LoadScene("game");
    }

    public static int GetDifficulty() {
        return difficulty;
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
    private void OnlyShowChild(GameObject section, int childNumber) {
        GameObject[] sectionChildren = GetChildren(section);

        if (childNumber >= sectionChildren.Length) {
            Debug.Log("You're trying to access a child that doesn't exist!");
        }

        for (int i = 0; i < sectionChildren.Length; i++) {
            if (sectionChildren[i].activeInHierarchy) {
                sectionChildren[i].SetActive(false);
            }
        }
        sectionChildren[childNumber].SetActive(true);
    }

    private bool AbleToContinue() {
        return seenNatural && seenManMade;
    }

    private void ActivateContinue() {
        GameObject[] lowerChildren = GetChildren(lowerSection);
        GameObject[] buttons = GetChildren(lowerChildren[0]);
        GameObject grayButton = buttons[5];
        GameObject redButton = buttons[6];

        grayButton.SetActive(false);
        redButton.SetActive(true);
    }

    private void DifficultySetup() {
        GameObject[] upperChildren = GetChildren(upperSection);
        GameObject[] defaultElements = GetChildren(upperChildren[0]);
        GameObject warningText = defaultElements[1];
        string warning = "";
        switch(difficulty) {
            case 1:
                warning = "Category 1 hurricane to hit NC coast";
                break;

            case 2:
                warning = "Category 3 hurricane to hit NC coast";
                break;

            case 3:
                warning = "Category 5 hurricane to hit NC coast";
                break;
        }

        Debug.Log("Our random number generator returned difficulty " + difficulty);
        Debug.Log("This translates to the warning '" + warning + "'");

        warningText.GetComponent<Text>().text = warning;
    }
}
