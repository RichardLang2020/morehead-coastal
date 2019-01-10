using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        for(int i = 0; i < sectionArray.Length; i++) {
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
        Debug.Log(getChildren(upperSection)[1].activeInHierarchy);

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

    // Returns all immediate children for a given GameObject
    GameObject[] getChildren(GameObject g) {
        GameObject[] output = new GameObject[g.transform.childCount];
        
        for(int i = 0; i < output.Length; i++) {
            output[i] = g.transform.GetChild(i).gameObject;
        }

        return output;
    }

    // Stalls for a given amount of time
    IEnumerator StallTime(int t) {
        yield return new WaitForSeconds(t);
    }

    public void ShowSandDuneInfo() {
        onlyShowChild(upperSection, 1);
        if(firstChange) {
            firstChange = false;
            onlyShowChild(middleSection, 1);
        }
        seenNatural = true;
        if(ableToContinue()) {
            activateContinue();
        }
    }
    public void ShowSeaGrassInfo()
    {
        onlyShowChild(upperSection, 2);
        if (firstChange)
        {
            firstChange = false;
            onlyShowChild(middleSection, 1);
        }
        seenNatural = true;
        if (ableToContinue())
        {
            activateContinue();
        }
    }
    public void ShowOysterReefInfo()
    {
        onlyShowChild(upperSection, 3);
        if (firstChange)
        {
            firstChange = false;
            onlyShowChild(middleSection, 1);
        }
        seenNatural = true;
        if (ableToContinue())
        {
            activateContinue();
        }
    }
    public void ShowFloodgateInfo()
    {
        onlyShowChild(upperSection, 4);
        if (firstChange)
        {
            firstChange = false;
            onlyShowChild(middleSection, 1);
        }
        seenManMade = true;
        if (ableToContinue())
        {
            activateContinue();
        }
    }
    public void ShowBulkheadInfo()
    {
        onlyShowChild(upperSection, 5);
        if (firstChange)
        {
            firstChange = false;
            onlyShowChild(middleSection, 1);
        }
        seenManMade = true;
        if (ableToContinue())
        {
            activateContinue();
        }
    }

    private void onlyShowChild(GameObject section, int childNumber)
    {
        GameObject[] sectionChildren = getChildren(section);

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

    private bool ableToContinue() {
        return seenNatural && seenManMade;
    }

    private void activateContinue() {
        GameObject[] lowerChildren = getChildren(lowerSection);
        GameObject[] buttons = getChildren(lowerChildren[0]);
        GameObject grayButton = buttons[5];
        GameObject redButton = buttons[6];

        grayButton.SetActive(false);
        redButton.SetActive(true);
    }
}
