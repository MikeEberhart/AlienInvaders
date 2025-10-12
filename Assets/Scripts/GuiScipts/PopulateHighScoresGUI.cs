using TMPro;
using UnityEngine;

public class PopulateHighScoresGUI : MonoBehaviour
{
    public TMP_Text firstPlace;
    public TMP_Text secondPlace;
    public TMP_Text thirdPlace;
    public TMP_Text fourthPlace;
    public TMP_Text fifthPlace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPlace.text = PlayerPrefs.GetInt("HighScore0", 0).ToString();
        secondPlace.text = PlayerPrefs.GetInt("HighScore1", 0).ToString();
        thirdPlace.text = PlayerPrefs.GetInt("HighScore2", 0).ToString();
        fourthPlace.text = PlayerPrefs.GetInt("HighScore3", 0).ToString();
        fifthPlace.text = PlayerPrefs.GetInt("HighScore4", 0).ToString();
    }
}
