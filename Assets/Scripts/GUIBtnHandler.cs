using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIBtnHandler : MonoBehaviour
{
    public GameObject menu;
    public GameObject highScoresGUI;
    //public Canvas menuBackground;
    public TMP_Text exitBtn;
    public TMP_Text playBtn;
    public TMP_Text guideBtn;
    //public GameObject gameMenu;

    private bool gameSceneLoaded;
    private bool gamePaused;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameSceneLoaded = false;
        gamePaused = false;
        highScoresGUI.SetActive(false);
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        //SceneManager.LoadScene("BtnBackground", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    public void Update()
    {
        KeyBindings();
    }
    private void ManageActiveScene()
    {
        Scene currScene = SceneManager.GetActiveScene();
        if(currScene == SceneManager.GetSceneByName("MainMenu"))
        {

        }
        else if(currScene == SceneManager.GetSceneByName("GameScene"))
        {

        }
        else if(currScene == SceneManager.GetSceneByName("HighScores"))
        {

        }
    }
    public void PlayGame() // play/resume
    {
        Scene currScene = SceneManager.GetActiveScene();
        if (currScene == SceneManager.GetSceneByName("MainMenu") || currScene == SceneManager.GetSceneByName("HighScores"))
        {
            DontDestroyOnLoad(gameObject);
            menu.SetActive(false);
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
            Debug.Log("Game Info");
            DontDestroyOnLoad(gameObject);
            menu.SetActive(false);
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
        if(currScene == SceneManager.GetSceneByName("MainMenu"))
        {
            DontDestroyOnLoad(gameObject);
            menu.SetActive(false);
            SceneManager.LoadScene("HighScores");
            highScoresGUI.SetActive(true);
            gameSceneLoaded = true;
        }
        else if(currScene == SceneManager.GetSceneByName("GameScene"))
        {
            SceneManager.LoadScene("HighScores");
            PauseGame();
            highScoresGUI.SetActive(true);
            gameSceneLoaded = true;
        }
    }
    public void ExitGame()
    {
        //only works on a full build
        //Debug.Log("Exit Game");
        Application.Quit();
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
            menu.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
            exitBtn.text = "Main Menu";
            playBtn.text = "Resume";
            guideBtn.text = "Restart";
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
            exitBtn.text = "Exit";
            playBtn.text = "Play";
            guideBtn.text = "Guide";
        }
    }
}
