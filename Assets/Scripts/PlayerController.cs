using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    BasicWeaponHandler basicWeapon;
    SpecialWeaponHandler specialWeapon;
    Rigidbody2D rb;
    public GameObject shields;
    //decided to go with static object here instead of passing the object through multiple scripts
    public static GameObject playerJet;
    public float speed = 5f;
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
        shields.SetActive(false);
        cooldownActive = false;
        shieldsEquipped = false;
        shieldsActive = false;
        misslesEquipped = false;
        playerJet = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerKeyBindings();
        tempCooldown -= Time.deltaTime;
        if (tempCooldown <= 0)
        {
            cooldownActive = false;
        }
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
            //if no shields then gameover
            //if shields then shot destorys shields giving player another chance
            if (!shieldsEquipped)
            {
                //gameover
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            }
            else if(!shieldsActive)
            {
                SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            }
            else
            {
                //-1 from shields
                Destroy(other.gameObject);
                shields.SetActive(false);
                shieldsActive = false;
                shieldsEquipped = false;
            }
            Debug.Log("Game Over PlasmShot");
        }
        else if (other.gameObject.CompareTag("ShieldPowerUp"))
        {
            Destroy(other.gameObject);
            shieldsEquipped = true;
            //needs bool and something to check if shields are already online
            //or could have player push a button to turn on shields
        }
        else if(other.gameObject.CompareTag("MisslePowerUp"))
        {
            Destroy(other.gameObject);
            misslesEquipped = true;
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
