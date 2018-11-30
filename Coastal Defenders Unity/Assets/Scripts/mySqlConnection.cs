using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mySqlConnection : MonoBehaviour {

    // Use this for initialization
    public string url = "localhost:4000/leaderboard/scores";
    public ScoreEntry[] scoreEntries;
    public Button yourButton;

    void Start () {
        yourButton.onClick.AddListener(outputScores);
        StartCoroutine(getScores());
    }

    void outputScores()
    {
        for(int i=0; i<scoreEntries.Length; i++)
        {
            Debug.Log(i + ": " + scoreEntries[i].player_initials + ": " + scoreEntries[i].total_score);
        }
    }

    IEnumerator getScores()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            scoreEntries = JsonHelper.FromJson<ScoreEntry>(www.text);

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

[System.Serializable]
public class ScoreEntry
{
    public int id = 0;
    public string player_initials = "test";
    public int total_score = 1;
    public int land_saved_score = 1;
    public int human_protection_score = 1;
    public int animal_protection_score = 1;
    public string created_at = "date";
}