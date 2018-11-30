using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigationButton : MonoBehaviour
{

    public Button yourButton;
    public string navToScene;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
       SceneManager.LoadScene(navToScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
