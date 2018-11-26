using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class subtitleTiming : MonoBehaviour {

    public GameObject textBox;
    public bool textComplete;

	// Use this for initialization
	void Start() {
        textComplete = false;
        StartCoroutine(TheSequence());
	}
	
	IEnumerator TheSequence() {
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Hurricane-related storm surge can \n result in high waves and flooding.";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "It causes damage to property, \n ecosystems, injuries, and even deaths.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "But, with a combination of solutions, \n we may be able to lessen their effects.";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "How much of the coast can you save?";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        textComplete = true;
    }
}
