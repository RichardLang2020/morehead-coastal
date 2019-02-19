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
    public Text coinDisplay;

    /*
     * 0 - Sand Dunes
     * 1 - Oyster Reefs
     * 2 - Bulkheads
     * 3 - Floodgates
     * 4 - Sandgrass
     */
    private int[] currentResourceNumbers;
    private int[] maxResourceNumbers;
    private int[] resourceCosts;
    private int coins;
    private bool firstChange;
    private static int difficulty;
    private int currentPhase;

    void Start() {
        difficulty = ResourceInfoController.GetDifficulty();
        currentResourceNumbers = new int[5];
        maxResourceNumbers = new int[5] {4, 4, 2, 1, 3};
        resourceCosts = new int[5] {20, 30, 50, 100, 25};
        switch (difficulty) {
            case 1:
                coins = 230;
                break;

            case 2:
                coins = 200;
                break;

            case 3:
                coins = 170;
                break;

            default:
                coins = 200;
                break;
        }
        coinDisplay.text = coins.ToString();
        currentPhase = 1;

        // Get ready to play the introduction video

        // Confirm that the introduction video has finished, start swapping things into the main game
        // Call on the difficulty to make sure we're loading things in properly for coins and maps
        firstChange = true;
        
        MainTimer(timerText, 180);

        Debug.Log("Printing some stuff after the main timer to see if multithreading is active");
    }

    // Update is called once per frame
    void Update() {

    }

    public void NextScreen() {
        SceneManager.LoadScene("mainmenu");
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
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[resourceNumber + 1];
        GameObject desiredResource = GetChildren(resourceArray)[currentResourceNumbers[resourceNumber]];

        desiredResource.SetActive(true);

        coins = coins - resourceCosts[resourceNumber];
        coinDisplay.text = coins.ToString();

        currentResourceNumbers[resourceNumber]++;

        // Deactivate the "+" button for any resource that we can no longer afford
        for(int i = 0; i < currentResourceNumbers.Length; i++) {
            if(resourceCosts[i] > coins) {
                GameObject resourceButtons = GetChildren(lowerSection)[i + 1];
                GameObject grayPlus = GetChildren(resourceButtons)[2];
                GameObject bluePlus = GetChildren(resourceButtons)[4];

                grayPlus.SetActive(true);
                bluePlus.SetActive(false);
            }
        }
        // Deactivate the "+" button for resources after we hit the max number of that resource
        if(currentResourceNumbers[resourceNumber] == maxResourceNumbers[resourceNumber]) {
            GameObject resourceButtons = GetChildren(lowerSection)[resourceNumber + 1];
            GameObject grayPlus = GetChildren(resourceButtons)[2];
            GameObject bluePlus = GetChildren(resourceButtons)[4];

            grayPlus.SetActive(true);
            bluePlus.SetActive(false);
        }
        // Reactivate the "-" button after we get over 0 of that resource
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
        currentResourceNumbers[resourceNumber]--;
        GameObject mainGame = GetChildren(upperSection)[1];
        GameObject resourceArray = GetChildren(mainGame)[resourceNumber+ 1];
        GameObject desiredResource = GetChildren(resourceArray)[currentResourceNumbers[resourceNumber]];

        desiredResource.SetActive(false);

        coins = coins + resourceCosts[resourceNumber];
        coinDisplay.text = coins.ToString();

        // Reactivate the "+" button for resources that we can now afford
        for (int i = 0; i < currentResourceNumbers.Length; i++) {
            if (resourceCosts[i] <= coins && currentResourceNumbers[i] < maxResourceNumbers[i]) {
                GameObject resourceButtons = GetChildren(lowerSection)[i + 1];
                GameObject grayPlus = GetChildren(resourceButtons)[2];
                GameObject bluePlus = GetChildren(resourceButtons)[4];

                grayPlus.SetActive(false);
                bluePlus.SetActive(true);
            }
        }
        // Reactivate the "+" button for resources after we get under the max number of that resource
        if (currentResourceNumbers[resourceNumber] == maxResourceNumbers[resourceNumber] - 1) {
            GameObject resourceButtons = GetChildren(lowerSection)[resourceNumber + 1];
            GameObject grayPlus = GetChildren(resourceButtons)[2];
            GameObject bluePlus = GetChildren(resourceButtons)[4];

            grayPlus.SetActive(false);
            bluePlus.SetActive(true);
        }
        // Deactivate the "-" button for resources if we get to 0 as the current number of that resource
        if (currentResourceNumbers[resourceNumber] == 0) {
            GameObject resourceButtons = GetChildren(lowerSection)[resourceNumber + 1];
            GameObject grayMinus = GetChildren(resourceButtons)[1];
            GameObject blueMinus = GetChildren(resourceButtons)[3];

            grayMinus.SetActive(true);
            blueMinus.SetActive(false);
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

    // Runs the timer and prints it to the timerText
    private void MainTimer(Text timerText, int seconds) {
        int secondsRemaining = seconds;

        if(secondsRemaining >= 0) {
            int currentMinutes = secondsRemaining / 60;
            int currentSeconds = secondsRemaining % 60;

            string minutesString = currentMinutes.ToString();
            string secondsString = currentSeconds.ToString();
            if (currentSeconds < 10) {
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
