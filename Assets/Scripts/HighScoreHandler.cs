using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    private List<int> highScores = new List<int>();
    private PlayerController pController;
    public GameObject player;
    private ScoreHandler sHandler;
    private int highScore;
    private int currScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pController = player.GetComponent<PlayerController>();
        sHandler = GetComponent<ScoreHandler>();
        PlayerPrefs.DeleteAll();
        WriteHighScore(752);
        WriteHighScore(2);
        ReadHighScore();
        foreach(int i in highScores)
        {
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currScore = pController.GetPlayerScore();
    }

    public void WriteHighScore(int score)
    {
        int count = highScores.Count;
        Debug.Log(count);
        string name = "HighScore" + (count + 1);
        PlayerPrefs.SetInt(name, score);
        //PlayerPrefs.SetInt("HighScore1", 0);
        //PlayerPrefs.SetInt("HighScore2", 0);
        //PlayerPrefs.SetInt("HighScore3", 0);
        //PlayerPrefs.SetInt("HighScore4", 0);
        //PlayerPrefs.SetInt("HighScore5", 0);
    }
    public List<int> ReadHighScore()
    {
        for (int i = 0; i < 5; i++)
        {
            string scoreName = "HighScore" + (i + 1);
            int hScore = PlayerPrefs.GetInt(scoreName, 0);
            highScores.Add(hScore);
        }
        SortHighScores();
        return highScores;
    }

    private void SortHighScores()
    {
        highScores.Sort();
        highScores.Reverse();
        if(highScores.Count > 5)
        {
            //highScores.RemoveAt(5);
            highScores.RemoveRange(5, highScores.Count);
        }
    }
}
