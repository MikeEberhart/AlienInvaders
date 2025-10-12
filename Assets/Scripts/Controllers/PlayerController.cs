using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static GameObject playerJet;
    private GUIBtnHandler guiBtnsHandler;
    private ScoreHandler sHandler;
    public GameObject gameplayGUI;
    private BasicWeaponHandler bWeaponHandler;
    private SpecialWeaponHandler sWeaponHandler;
    private Rigidbody2D rb;
    public GameObject shields;
    public float speed = 5f;
    private int currScore;
    private int highScore;
    public float missleCooldown;
    private float tempMissleCooldown;
    private bool cooldownActive;
    private bool shieldsEquipped;
    private bool shieldsActive;
    private bool misslesEquipped;
    private int missleCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        tempMissleCooldown = missleCooldown;
        rb = GetComponent<Rigidbody2D>();
        bWeaponHandler = gameObject.GetComponent<BasicWeaponHandler>();
        sWeaponHandler = gameObject.GetComponent<SpecialWeaponHandler>();
        sHandler = gameplayGUI.GetComponent<ScoreHandler>();
        guiBtnsHandler = GUIBtnHandler.guiBtns;
        shields.SetActive(false);
        cooldownActive = false;
        shieldsEquipped = false;
        shieldsActive = false;
        misslesEquipped = false;
        currScore = 0;
        missleCount = 0;
        playerJet = gameObject;

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
        //used to set/reset missle cooldown
        tempMissleCooldown -= Time.deltaTime;
        if (tempMissleCooldown <= 0)
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
    public int GetMissleCount()
    {
        return missleCount;
    }
    private void PlayerKeyBindings()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) //fire basic weapon
        {
            bWeaponHandler.FireWeapon();
        }
        else if(Input.GetKeyDown(KeyCode.R)) //shields
        {
            if(shieldsEquipped)
            {
                shields.SetActive(true);
                shieldsActive = true;
                shieldsEquipped = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.F) && !cooldownActive) //fire missle
        {
            //fire missle
            if (misslesEquipped)
            {
                sWeaponHandler.FireMissle();
                missleCount--;
                tempMissleCooldown = missleCooldown;
                cooldownActive = true;
                if (missleCount <= 0)
                {
                    misslesEquipped = false;
                }
            }
        }
    }
    private void PlayerMovement()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
        float yPos = Input.GetAxisRaw("Vertical");
        Vector2 pMove = new Vector2(xPos, yPos).normalized;
        rb.linearVelocity = pMove * speed;
    }
    private void ShieldHandler()
    {
        if(shieldsActive)
        {
            shields.SetActive(false);
            shieldsActive = false;
        }
        else
        {
            sHandler.CheckAndSetHighScore(true);
            guiBtnsHandler.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //maybe it would be better to put all this in each object rather than all in the player script?
        if(other.gameObject.CompareTag("Building"))
        {
            ShieldHandler();
            Debug.Log("Game Over Building");
        }
        else if(other.gameObject.CompareTag("UFO"))
        {
            ShieldHandler();
        }
        else if (other.gameObject.CompareTag("StormCloud"))
        {
            ShieldHandler();
            Debug.Log("Game Over StormCloud");
        }
        else if (other.gameObject.CompareTag("PlasmaShot"))
        {
            Destroy(other.gameObject);
            ShieldHandler();
            Debug.Log("Game Over PlasmShot");
        }
        else if (other.gameObject.CompareTag("ShieldPowerUp"))
        {
            Destroy(other.gameObject);
            shieldsEquipped = true;
        }
        else if(other.gameObject.CompareTag("MisslePowerUp"))
        {
            missleCount = missleCount + 2;
            Destroy(other.gameObject);
            misslesEquipped = true;
        }
        else if(other.gameObject.CompareTag("Coin"))
        {
            UpdatePlayerScore(other.GetComponent<CoinData>().GetCoinValue());
            other.GetComponent<CoinData>().DestoryCoin();
        }
    }
    public bool GetShieldsEquippedStatus()
    {
        return shieldsEquipped;
    }
    public bool GetShieldsActiveStatus()
    {
        return shieldsActive;
    }
}
