﻿using System.Collections;
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
    public Text timerText;

    /*
     * 1 - Sand Dunes
     * 2 - Oyster Reefs
     * 3 - Bulkheads
     * 4 - Floodgates
     * 5 - Sandgrass
     */
    private int[] resourceNumbers;
    private bool firstChange;
    private static int difficulty;

    void Start()
    {
        resourceNumbers = new int[5];
        // Get ready to play the introduction video

        // Confirm that the introduction video has finished, start swapping things into the main game
        // Call on the difficulty to make sure we're loading things in properly for coins and maps
        firstChange = true;
        
        MainTimer(timerText, 180);

        Debug.Log("Printing some stuff after the main timer to see if multithreading is active");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScreen()
    {
        SceneManager.LoadScene("game");
    }

    public void AddSandDune() {
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[1];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[0]];
        
        desiredResource.SetActive(true);

        // Decrease Money
        resourceNumbers[0]++;
    }
    public void AddOysterReef() {
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[2];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[1]];

        desiredResource.SetActive(true);

        // Decrease Money
        resourceNumbers[1]++;
    }
    public void AddBulkhead() {
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[3];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[2]];

        desiredResource.SetActive(true);

        // Decrease Money
        resourceNumbers[2]++;
    }
    public void AddFloodgate() {
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[4];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[3]];

        desiredResource.SetActive(true);

        // Decrease Money
        resourceNumbers[3]++;
    }
    public void AddSeaGrass() {
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[5];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[4]];

        desiredResource.SetActive(true);

        // Decrease Money
        resourceNumbers[4]++;
    }

    public void RemoveSandDune() {
        resourceNumbers[0]--;
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[1];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[0]];

        desiredResource.SetActive(false);

        // Increase Money
    }
    public void RemoveOysterReef() {
        resourceNumbers[1]--;
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[2];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[1]];

        desiredResource.SetActive(false);

        // Increase Money
    }
    public void RemoveBulkhead() {
        resourceNumbers[2]--;
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[3];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[2]];

        desiredResource.SetActive(false);

        // Increase Money
    }
    public void RemoveFloodgate() {
        resourceNumbers[3]--;
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[4];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[3]];

        desiredResource.SetActive(false);

        // Increase Money
    }
    public void RemoveSeaGrass() {
        resourceNumbers[4]--;
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[5];
        GameObject desiredResource = GetChildren(resourceArray)[resourceNumbers[4]];

        desiredResource.SetActive(false);

        // Increase Money
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

    // Runs the timer and prints it to the timerText
    private void MainTimer(Text timerText, int seconds) {
        int secondsRemaining = seconds;

        if(secondsRemaining >= 0) {
            int currentMinutes = secondsRemaining / 60;
            int currentSeconds = secondsRemaining % 60;

            string minutesString = currentMinutes.ToString();
            string secondsString = currentSeconds.ToString();
            if (currentSeconds < 10)
            {
                secondsString = '0' + currentSeconds.ToString();
            }
            timerText.text = minutesString + ":" + secondsString;

            secondsRemaining--;
            StartCoroutine(TimeStall(timerText, secondsRemaining, 1));
        } else {
            timerText.text = "Finished!";
            Debug.Log("Timer finished!");
        }
    }

    IEnumerator TimeStall(Text timerText, int seconds, int stallTime) {
        yield return new WaitForSeconds(stallTime);
        MainTimer(timerText, seconds);
    }
}
