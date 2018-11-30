using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitTime : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.3f);

        this.GetComponent<UnityEngine.UI.RawImage>().color = new Color();
        print(Time.time);
    }

    // Update is called once per frame
    void Update () {
        //this.GetComponent<UnityEngine.UI.RawImage>().color = Color.Lerp(this.GetComponent<UnityEngine.UI.RawImage>().color, new Color(), Time.deltaTime);
	}
}
