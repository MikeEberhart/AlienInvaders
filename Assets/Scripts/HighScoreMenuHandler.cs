using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Build.Player;

public class HighScoreMenuHandler : MonoBehaviour
{
    private List<int> scoreList = new List<int>();
    public List<TMP_Text> textboxList = new List<TMP_Text>();
    int maxScores = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PopulateHighScoreList();
        LoadHighScoreData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LoadHighScoreData()
    {
        foreach(int score in scoreList)
        {
            textboxList[score].text = scoreList[score].ToString();
        }
    }

    private void PopulateHighScoreList()
    {
        //used to populate/repopulate the highScores list when the game scene loads
        //with the saved scores from the player prefs
        scoreList.Clear();
        for (int i = 0; i < maxScores; i++)
        {
            string name = "HighScore" + i.ToString();
            int tempScore = PlayerPrefs.GetInt(name, 0);
            scoreList.Add(tempScore);
            Debug.Log("PopList: " + name + " - " + tempScore);
        }
    }
}
