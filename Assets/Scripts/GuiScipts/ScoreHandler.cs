using System;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public TMP_Text currScore;
    public TMP_Text highScore;
    public GameObject player;
    public int timeScoreMultiplier;
    public int timeBetweenPoints;
    private PlayerController pController;
    private HighScoreHandler hsHandler;
    private GameClock gClock;
    private float clock;
    private bool isPlayerDestroyed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pController = player.GetComponent<PlayerController>();
        hsHandler = GetComponent<HighScoreHandler>();
        gClock = GetComponent<GameClock>();
        timeScoreMultiplier = 2;
        timeBetweenPoints = 3;
        pController.SetHighScore(hsHandler.GetHighestScore());
        SetHighScoreText();
        isPlayerDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreFromTimer();
        SetCurrScoreText();
    }
    public void SetIsPlayerDestroyed(bool player)
    {
        isPlayerDestroyed = player;
    }
    public void SetHighScoreText()
    {
        highScore.text = pController.GetHighScore().ToString();
    }
    public void SetCurrScoreText()
    {
        currScore.text = pController.GetPlayerScore().ToString();
        if(pController.GetPlayerScore() > hsHandler.GetHighestScore())
        {
            highScore.text = currScore.text;
        }
        else
        {
            highScore.text = hsHandler.GetHighestScore().ToString();
        }
    }
    private void ScoreFromTimer()
    {
        //every 3 seconds player earns some points based off the multiplier with a base of 2
        //both the intervals and multiplier can be changed
        //I started with this method then trying to switch to Time.deltaTime
        //but that breaks the function for some reason. Might have to check into this later.
        clock = gClock.GetPassedClock();
        if(clock >= timeBetweenPoints)
        {
            pController.UpdatePlayerScore(timeBetweenPoints * timeScoreMultiplier);
            gClock.ResetPassedClock();
        }
    }
    public void CheckAndSetHighScore(bool isDest)
    {
        Debug.Log("isPlayerDestroyed: " + isDest);
        if (isDest)
        {
            if (hsHandler.IsGreaterThanFifthPlace(pController.GetPlayerScore()))// && !hsHandler.IsAlreadyInTopFive(pController.GetPlayerScore()))
            {
                pController.SetHighScore(pController.GetPlayerScore());
                hsHandler.AddNewHighScore(pController.GetPlayerScore());
                SetHighScoreText();
            }
        }
    }
}
