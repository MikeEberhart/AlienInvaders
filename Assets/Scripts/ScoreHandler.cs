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
    private int seconds;
    private int score;
    private int tempSec;
    private int clock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pController = player.GetComponent<PlayerController>();
        hsHandler = GetComponent<HighScoreHandler>();
        gClock = GetComponent<GameClock>();
        timeScoreMultiplier = 2;
        timeBetweenPoints = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //clock = gClock.GetGameClock();
        ScoreFromTimer();
        currScore.text = pController.GetPlayerScore().ToString();
    }
    private void ScoreFromTimer()
    {
        //every 3 seconds player earns some points based off the multiplier with a base of 2
        //both the intervals and multiplier can be changed
        clock = gClock.GetGameClock();
        if(clock >= timeBetweenPoints)
        {
            //tempSec++;
            pController.UpdatePlayerScore(timeBetweenPoints * timeScoreMultiplier);
            gClock.ResetPassedClock();
        }
        //tempSec = tempSec * timeBetweenPoints;
        //score = (tempSec * timeBetweenPoints) * timeScoreMultiplier;
        ////currScore.text = score.ToString();
        //pController.UpdatePlayerScore(score);
        

        //Debug.Log(score);

    }
}
