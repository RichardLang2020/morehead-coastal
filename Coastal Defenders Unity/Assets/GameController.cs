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
    public Text timerText;

    /*
     * 0 - Sand Dunes
     * 1 - Oyster Reefs
     * 2 - Bulkheads
     * 3 - Floodgates
     * 4 - Sandgrass
     */
    private int[] currentResourceNumbers;
    private int[] maxResourceNumbers;
    private bool firstChange;
    private static int difficulty;

    void Start()
    {
        currentResourceNumbers = new int[5];
        maxResourceNumbers = new int[5] {4, 4, 2, 1, 3};
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
        addResource(0);
    }
    public void AddOysterReef() {
        addResource(1);
    }
    public void AddBulkhead() {
        addResource(2);
    }
    public void AddFloodgate() {
        addResource(3);
    }
    public void AddSeaGrass() {
        addResource(4);
    }

    public void RemoveSandDune() {
        removeResource(0);
    }
    public void RemoveOysterReef() {
        removeResource(1);
    }
    public void RemoveBulkhead() {
        removeResource(2);
    }
    public void RemoveFloodgate() {
        removeResource(3);
    }
    public void RemoveSeaGrass() {
        removeResource(4);
    }

    // Adds one of the given resource number - these numbers are -1 from the values in the currentResourceNumbers array
    private void addResource(int resourceNumber) {
        if (currentResourceNumbers[resourceNumber] == maxResourceNumbers[resourceNumber]) {
            string resourceName;

            switch (resourceNumber) {
                case 0:
                    resourceName = "Sand Dunes";
                    break;
                case 1:
                    resourceName = "Oyster Reefs";
                    break;
                case 2:
                    resourceName = "Bulkheads";
                    break;
                case 3:
                    resourceName = "Floodgates";
                    break;
                case 4:
                    resourceName = "Sea Grasses";
                    break;
                default:
                    resourceName = "Unknown Resource";
                    break;
            }

            Debug.Log("You've placed too many " + resourceName);
            return;
        }

        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[resourceNumber + 1];
        GameObject desiredResource = GetChildren(resourceArray)[currentResourceNumbers[resourceNumber]];

        desiredResource.SetActive(true);

        // Decrease Money
        currentResourceNumbers[resourceNumber]++;

        if(currentResourceNumbers[resourceNumber] == maxResourceNumbers[resourceNumber]) {
            GameObject resourceButtons = GetChildren(lowerSection)[resourceNumber + 1];
            GameObject grayPlus = GetChildren(resourceButtons)[2];
            GameObject bluePlus = GetChildren(resourceButtons)[4];

            grayPlus.SetActive(true);
            bluePlus.SetActive(false);
        }
        if (currentResourceNumbers[resourceNumber] == 1) {
            GameObject resourceButtons = GetChildren(lowerSection)[resourceNumber + 1];
            GameObject grayMinus = GetChildren(resourceButtons)[1];
            GameObject blueMinus = GetChildren(resourceButtons)[3];

            grayMinus.SetActive(false);
            blueMinus.SetActive(true);
        }
    }
    // Removes one of the given resource number
    private void removeResource(int resourceNumber) {
        if (currentResourceNumbers[resourceNumber] == 0) {
            string resourceName;

            switch (resourceNumber) {
                case 0:
                    resourceName = "Sand Dunes";
                    break;
                case 1:
                    resourceName = "Oyster Reefs";
                    break;
                case 2:
                    resourceName = "Bulkheads";
                    break;
                case 3:
                    resourceName = "Floodgates";
                    break;
                case 4:
                    resourceName = "Sea Grasses";
                    break;
                default:
                    resourceName = "Unknown Resource";
                    break;
            }

            Debug.Log("You cannot remove any since you don't have any " + resourceName);
            return;
        }

        currentResourceNumbers[resourceNumber]--;
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[resourceNumber+ 1];
        GameObject desiredResource = GetChildren(resourceArray)[currentResourceNumbers[resourceNumber]];

        desiredResource.SetActive(false);

        // Increase Money
        if (currentResourceNumbers[resourceNumber] == maxResourceNumbers[resourceNumber] - 1) {
            GameObject resourceButtons = GetChildren(lowerSection)[resourceNumber + 1];
            GameObject grayPlus = GetChildren(resourceButtons)[2];
            GameObject bluePlus = GetChildren(resourceButtons)[4];

            grayPlus.SetActive(false);
            bluePlus.SetActive(true);
        }
        if (currentResourceNumbers[resourceNumber] == 0) {
            GameObject resourceButtons = GetChildren(lowerSection)[resourceNumber + 1];
            GameObject grayMinus = GetChildren(resourceButtons)[1];
            GameObject blueMinus = GetChildren(resourceButtons)[3];

            grayMinus.SetActive(true);
            blueMinus.SetActive(false);
        }
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
