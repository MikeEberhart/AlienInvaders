using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    private List<int> highScores = new List<int>();
    private int maxScores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxScores = 5;
        PopulateHighScoreList();
        //was using this to reset PlayerPref data
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool IsGreaterThanFifthPlace(int pScore)
    {
        if(pScore > highScores[4])
        {
            return true;
        }
        return false;
    }
    public int GetHighestScore()
    {
        Debug.Log(highScores[0]);
        return highScores[0];
    }
    public void AddNewHighScore(int highScore)
    {
        highScores.Add(highScore);
        SortHighScores();
        SaveHighScoreList();
    }
    //public bool 
    private void SaveHighScoreList()
    {
        for(int i = 0; i < highScores.Count; i++)
        {
            string name = "HighScore" + i;
            PlayerPrefs.SetInt(name, highScores[i]);
            Debug.Log("SavingList: " + name + " - " + highScores[i]);
        }
        PlayerPrefs.Save();
    }
    public void SaveSingleScore(int score)
    {
        int count = highScores.Count;
        Debug.Log("Write - highScore cnt: " + count);
        string name = "HighScore" + (count + 1);
        PlayerPrefs.SetInt(name, score);
        PlayerPrefs.Save();
    }
    private void PopulateHighScoreList()
    {
        //used to populate/repopulate the highScores list when the game scene loads
        //with the saved scores from the player prefs
        highScores.Clear();
        for (int i = 0; i < maxScores; i++)
        {
            string name = "HighScore" + i.ToString();
            int tempScore = PlayerPrefs.GetInt(name, 0);
            highScores.Add(tempScore);
            Debug.Log("PopList: " + name + " - " + tempScore);
        }
    }
    private void SortHighScores()
    {
        //was originally thinking of doing something like bubble sort for this but remembered .Sort()
        highScores.Sort();
        highScores.Reverse();
        if (highScores.Count > maxScores)
        {
            highScores = highScores.GetRange(0, maxScores);
            Debug.Log("Delete last score");
        }
        foreach (int i in highScores)
        {
            Debug.Log("Sort cnt: " + i);
        }
    }
}
