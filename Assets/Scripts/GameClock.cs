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

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        passedClock += Time.deltaTime;
        ClockCounter();
    }

    private void ClockCounter()
    {
        //clock += Time.deltaTime;
        min = (int)(clock / 60);
        sec = (int)(clock % 60);
        time = string.Format("{0:00}:{1:00}", min, sec);
        clockDisplay.text = time;
    }
    public int GetPassedClock()
    {
        return (int)passedClock;
    }
    public void ResetPassedClock()
    {
        passedClock = 0f;
    }
}
