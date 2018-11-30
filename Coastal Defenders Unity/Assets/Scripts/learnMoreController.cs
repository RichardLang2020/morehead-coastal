using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class learnMoreController : MonoBehaviour {

    public Text hurricaneName;
    public Text date;
    public Text blurb;
    public Image catButton;
    public Sprite[] buttons;
    public Image image;
    public Sprite[] images;
    public Text wind;
    public Text surge;
    public Text property;
    public Text lives;
	// Use this for initialization
	void Start () {
        if (DiffController.levelselect == 1)
        {
            hurricaneName.text = "Hurricane Matthew";
            date.text = "October 8, 2016";
            blurb.text = "During Hurricane Matthew, river flood levels were the highest recorded in 20 years and caused millions of dollars of damage and multiple deaths across the eastern third of North Carolina.";
            catButton.sprite = buttons[0];
            wind.text = "94 mph";
            surge.text = "5.8 ft";
            property.text = "$1.6 billion";
            lives.text = "26";
            image.sprite = images[0];
        }
        else if (DiffController.levelselect == 2)
        {
            hurricaneName.text = "Hurricane Floyd";
            date.text = "September 16, 1999";
            blurb.text = "The rains produced from Hurricane Dennis and then Floyd triggered the fourth largest evacuation in US history.";
            catButton.sprite = buttons[1];
            wind.text = "90 mph";
            surge.text = "10 ft";
            property.text = "$6.5 billion";
            lives.text = "51";
            image.sprite = images[1];
        }
        else if (DiffController.levelselect == 3)
        {
            hurricaneName.text = "Hurricane Fran";
            date.text = "September 5, 1996";
            blurb.text = "As of 2018, Fran is the most recent major hurricane to make landfall in North Carolina. At the time, Fran was one of the ten costliest hurricanes to strike the United States.";
            catButton.sprite = buttons[2];
            wind.text = "137 mph";
            surge.text = "10 ft";
            property.text = "$2.4 billion";
            lives.text = "13";
            image.sprite = images[2];
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
