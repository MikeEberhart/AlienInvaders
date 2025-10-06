using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private HighScoreHandler hsHandler;
    private ScoreHandler sHandler;
    public GameObject gameplayGUI;
    private BasicWeaponHandler basicWeapon;
    private SpecialWeaponHandler specialWeapon;
    //GUIBtnHandler guiBtns;
    private Rigidbody2D rb;
    public GameObject shields;
    //decided to go with static object here instead of passing the object through multiple scripts
    public static GameObject playerJet;
    public float speed = 5f;
    private int currScore;
    private int highScore;
    private float time;
    private float delay;
    public float missleCooldown;
    private float tempCooldown;
    private bool cooldownActive;
    private bool shieldsEquipped;
    private bool shieldsActive;
    private bool misslesEquipped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempCooldown = missleCooldown;
        rb = GetComponent<Rigidbody2D>();
        basicWeapon = gameObject.GetComponent<BasicWeaponHandler>();
        specialWeapon = gameObject.GetComponent<SpecialWeaponHandler>();
        hsHandler = gameplayGUI.GetComponent<HighScoreHandler>();
        sHandler = gameplayGUI.GetComponent<ScoreHandler>();
        //guiBtns = gameObject.AddComponent<GUIBtnHandler>();
        shields.SetActive(false);
        //specialWeapon.SetShieldActivation(false);
        cooldownActive = false;
        shieldsEquipped = false;
        shieldsActive = false;
        misslesEquipped = false;
        currScore = 0;
        //highScore = hsHandler.GetHighestScore();
        //maybe look into passing via scripts and collisions rather than static
        //though there will only ever be one playerJet so should be any issue I dont think
        playerJet = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //used to check if the game is paused or not
        if (Time.timeScale != 0f)
        {
            PlayerMovement();
            PlayerKeyBindings();
        }
        tempCooldown -= Time.deltaTime;
        if (tempCooldown <= 0)
        {
            cooldownActive = false;
        }
    }
    public int GetPlayerScore()
    {
        return currScore;
    }
    public void UpdatePlayerScore(int score)
    {
        currScore += score;
    }
    public int GetHighScore()
    {
        return highScore;
    }
    public void SetHighScore(int hs)
    {
        highScore = hs;
    }
    private void PlayerKeyBindings()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) //fire basic weapon
        {
            basicWeapon.FireWeapon();
        }
        else if(Input.GetKeyDown(KeyCode.R)) //shields
        {
            //shields.SetActive(true);
            if(shieldsEquipped)
            {
                //specialWeapon.SetShieldActivation(true);
                shields.SetActive(true);
                shieldsActive = true;
                //specialWeapon.ShieldsOnline();
            }
        }
        else if (Input.GetKeyDown(KeyCode.F) && !cooldownActive) //fire missle
        {
            //fire missle
            if (misslesEquipped)
            {
                specialWeapon.FireMissle();
                tempCooldown = missleCooldown;
                cooldownActive = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.G)) //drop nuke??
        {
            //only one nuke per power up
        }
    }
    private void PlayerMovement()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
        float yPos = Input.GetAxisRaw("Vertical");
        Vector2 pMove = new Vector2(xPos, yPos).normalized;
        rb.linearVelocity = pMove * speed;
    }
    private void ShieldHandler(GameObject gObject)
    {
        //if no shields then gameover
        //if shields then shot destorys shields giving player another chance
        if (!shieldsEquipped)
        {
            //gameover
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if (!shieldsActive)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else
        {
            //-1 from shields
            if (!gObject.CompareTag("UFO") && !gObject.CompareTag("Building") && !gObject.CompareTag("StormCloud"))
            {
                Destroy(gObject);
            }
            //Destroy(gObject);
            shields.SetActive(false);
            //specialWeapon.SetShieldActivation(false);
            shieldsActive = false;
            shieldsEquipped = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //maybe it would be better to put all this in each object rather than all in this object script
        if(other.gameObject.CompareTag("Building"))
        {
            //gameover
            Debug.Log("Game Over Building");
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if(other.gameObject.CompareTag("UFO"))
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if (other.gameObject.CompareTag("StormCloud"))
        {
            //gameover
            Debug.Log("Game Over StormCloud");
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if (other.gameObject.CompareTag("PlasmaShot"))
        {
            //ShieldHandler(other.gameObject);
            Debug.Log("Game Over PlasmShot");
        }
        else if (other.gameObject.CompareTag("ShieldPowerUp"))
        {
            Destroy(other.gameObject);
            //specialWeapon.ShieldsEquipped();
            shieldsEquipped = true;
            //needs bool and something to check if shields are already online
            //or could have player push a button to turn on shields
        }
        else if(other.gameObject.CompareTag("MisslePowerUp"))
        {
            Destroy(other.gameObject);
            misslesEquipped = true;
        }
        else if(other.gameObject.CompareTag("Coin"))
        {
            UpdatePlayerScore(other.GetComponent<CoinData>().GetCoinValue());
            other.GetComponent<CoinData>().DestoryCoin();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            //gameover
            Debug.Log("Game Over Boundary");
        }
    }

}
