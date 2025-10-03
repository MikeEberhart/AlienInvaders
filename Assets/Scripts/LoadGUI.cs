using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGUI : MonoBehaviour
{
    private Scene btnGUI;
    private Scene background;
    private Scene highScores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadMenuBackground();
        LoadBtnGUI();
    }

    // Update is called once per frame
    void Update()
    {
        //probably dont need this
    }

    private void LoadMenuBackground()
    {
        background = SceneManager.GetSceneByName("MainMenu");
        if (!background.isLoaded)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
    private void LoadBtnGUI()
    {
        btnGUI = SceneManager.GetSceneByName("BtnBackground");
        if (!btnGUI.isLoaded)
        {
            SceneManager.LoadScene("BtnBackground", LoadSceneMode.Additive);
        }
    }
}
