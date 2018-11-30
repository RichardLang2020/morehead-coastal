using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBlurbController : MonoBehaviour {

    public Text blurb;
    public Image button;
    public Sprite[] buttons = new Sprite[3];
	// Use this for initialization
	void Start () {
		switch(DiffController.levelselect)
        {
            case 1:
                button.sprite = buttons[0];
                break;
            case 2:
                button.sprite = buttons[1];
                break;
            case 3:
                button.sprite = buttons[2];
                break;
            default:
                button.sprite = buttons[0];
                break;
        }
        float val = EffectivenessBarController.barDisplay;
        if (val < 0.25)
        {
            blurb.text = "Oh no! You failed to protect the coast. Try again?";

        } else if(val <0.5)
        {
            blurb.text = "Looks like your plan was no match for the storm surge. Better luck next time.";

        } else if(val <0.75)
        {
            blurb.text = "Your solutions kept most of the storm surge at bay. Think you can do better?";

        } else if(val <0.9)
        {
            blurb.text = "Strong work! You are an amazing Coastal Defender!";

        } else if(val < 2)
        {
            blurb.text = "Whoa! You are the ultimate Coastal Defender!";

        } else
        {
            blurb.text = "Try again!";

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
