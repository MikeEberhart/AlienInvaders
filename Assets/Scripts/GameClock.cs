using System;
using TMPro;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    public TMP_Text clockDisplay;
    private int min;
    private int sec;
    private float clock;
    private float passedClock;
    private string time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ClockCounter();
        //I put this second deltaTime here to make sure this one and the one
        //in ClockCounter start together and are synced up 
        passedClock += Time.deltaTime;
    }

    private void ClockCounter()
    {
        clock += Time.deltaTime;
        min = (int)(clock / 60);
        sec = (int)(clock % 60);
        time = string.Format("{0:00}:{1:00}", min, sec);
        clockDisplay.text = time;
    }
    public int GetGameClock()
    {
        //Debug.Log("passedClock" + (int)passedClock);
        return (int)passedClock;
    }
    public void ResetPassedClock()
    {
        passedClock = 0;
    }
}
