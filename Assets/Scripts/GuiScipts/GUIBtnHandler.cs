using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIBtnHandler : MonoBehaviour
{
    public static GUIBtnHandler guiBtns;
    public GameObject menuGUI;
    public GameObject highScoresGUI;
    public TMP_Text exitBtnText;
    public TMP_Text playBtnText;
    public TMP_Text guideBtnText;
    public GameObject exitBtn;
    public GameObject playBtn;
    public GameObject guideBtn;
    public GameObject highScoreBtn;
    public GameObject yesBtn;
    public GameObject noBtn;
    public GameObject playAgainLbl;

    private bool gameSceneLoaded;
    private bool gamePaused;

    void Start()
    {
        gameSceneLoaded = false;
        gamePaused = false;
        menuGUI.SetActive(true);
        highScoresGUI.SetActive(false);
        guiBtns = this;
        Time.timeScale = 1f;
    }

    public void Update()
    {
        KeyBindings();
    }
    public void PlayGame() // play/resume
    {
        Scene currScene = SceneManager.GetActiveScene();
        if (currScene == SceneManager.GetSceneByName("MainMenu"))
        {
            DontDestroyOnLoad(gameObject);
            gameSceneLoaded = true;
            SceneManager.LoadScene("GameScene");
            menuGUI.SetActive(false);
        }
        else if (currScene == SceneManager.GetSceneByName("GameScene"))
        {
            playBtnText.text = "Resume";
            PauseGame();
        }
    }
    public void GameInfo() // guide/restart
    {
        Scene currScene = SceneManager.GetActiveScene();
        if (currScene == SceneManager.GetSceneByName("MainMenu"))
        {
            DontDestroyOnLoad(gameObject);
            menuGUI.SetActive(false);
            highScoresGUI.SetActive(false);
            SceneManager.LoadScene("GameGuide");
        }
        else if(currScene == SceneManager.GetSceneByName("GameScene"))
        {

            gameSceneLoaded = true;
            SceneManager.LoadScene("GameScene");
            PauseGame();
        }
    }
    public void ShowHighScores() // high scores
    {
        Debug.Log("Show High Scores");
        Scene currScene = SceneManager.GetActiveScene();
        if (currScene == SceneManager.GetSceneByName("MainMenu"))
        {
            menuGUI.SetActive(false);
            highScoresGUI.SetActive(true);
        }
        else if(currScene == SceneManager.GetSceneByName("GameScene"))
        {
            menuGUI.SetActive(false);
            highScoresGUI.SetActive(true);
        }
    }
    public void ExitGame() //exit game
    { 
        Scene currScene = SceneManager.GetActiveScene();
        if (currScene == SceneManager.GetSceneByName("MainMenu"))
        {
            Application.Quit();
        }
        else if(currScene == SceneManager.GetSceneByName("GameScene"))
        {
            gameSceneLoaded = false;
            menuGUI.SetActive(false);
            highScoresGUI.SetActive(false);
            PauseGame();
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void BackButton() //back button for guide screen
    {
        Scene currScene = SceneManager.GetActiveScene();
        if (currScene == SceneManager.GetSceneByName("MainMenu") || currScene == SceneManager.GetSceneByName("GameScene"))
        {
            highScoresGUI.SetActive(false);
            menuGUI.SetActive(true);
        }
        else if(currScene == SceneManager.GetSceneByName("GameGuide"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void YesButton()// yes button for gameover menu
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        gameSceneLoaded = true;
        menuGUI.SetActive(false);
        MenuGUISwitch(false);
    }
    public void NoButton()//no button for game over menu
    {
        gameSceneLoaded = false;
        menuGUI.SetActive(false);
        MenuGUISwitch(false);
        SceneManager.LoadScene("MainMenu");
    }
    private void KeyBindings()//menu key bindings
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameSceneLoaded)
        {
            highScoresGUI.SetActive(false);
            PauseGame();
        }
    }
    private void PauseGame()
    {
        if (!gamePaused)
        {
            menuGUI.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
            exitBtnText.text = "Main Menu";
            playBtnText.text = "Resume";
            guideBtnText.text = "Restart";
        }
        else
        {
            menuGUI.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
            exitBtnText.text = "Exit";
            playBtnText.text = "Play";
            guideBtnText.text = "Guide";
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        menuGUI.SetActive(true);
        MenuGUISwitch(true);
    }

    private void MenuGUISwitch(bool active)
    {
        yesBtn.SetActive(active);
        noBtn.SetActive(active);
        playAgainLbl.SetActive(active);
        playBtn.SetActive(!active);
        guideBtn.SetActive(!active);
        highScoreBtn.SetActive(!active);
        exitBtn.SetActive(!active);
    }
}
