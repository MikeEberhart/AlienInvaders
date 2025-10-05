using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIBtnHandler : MonoBehaviour
{
    public GameObject menuGUI;
    public GameObject highScoresGUI;
    public TMP_Text exitBtn;
    public TMP_Text playBtn;
    public TMP_Text guideBtn;

    private bool gameSceneLoaded;
    private bool gamePaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameSceneLoaded = false;
        gamePaused = false;
        menuGUI.SetActive(true);
        highScoresGUI.SetActive(false);
    }

    // Update is called once per frame
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
            menuGUI.SetActive(false);
            gameSceneLoaded = true;
            SceneManager.LoadScene("GameScene");
            Debug.Log("Start Game");
        }
        else if (currScene == SceneManager.GetSceneByName("GameScene"))
        {
            playBtn.text = "Resume";
            PauseGame();
        }
    }
    public void GameInfo() // guide/restart
    {
        Scene currScene = SceneManager.GetActiveScene();
        //Debug.Log("Restart Game/Guide");
        if (currScene == SceneManager.GetSceneByName("MainMenu"))
        {
            //Debug.Log("Game Info");
            DontDestroyOnLoad(gameObject);
            menuGUI.SetActive(false);
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
        //do I need two of these?? would one be good?
        //is there anything else i might put here?
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
    public void ExitGame()
    { 
        Scene currScene = SceneManager.GetActiveScene();
        if (currScene == SceneManager.GetSceneByName("MainMenu"))
        {
            //only works on a full build
            //Debug.Log("Exit Game");
            Application.Quit();
        }
        else if(currScene == SceneManager.GetSceneByName("GameScene"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void KeyBindings()
    {
        //Debug.Log("Pause Game");
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
            exitBtn.text = "Main Menu";
            playBtn.text = "Resume";
            guideBtn.text = "Restart";
        }
        else
        {
            menuGUI.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
            exitBtn.text = "Exit";
            playBtn.text = "Play";
            guideBtn.text = "Guide";
        }
    }
    public void BackButton()
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
}
