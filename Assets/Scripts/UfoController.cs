using UnityEngine;

public class UfoController : MonoBehaviour
{
    private GameObject player;
    BasicWeaponHandler weaponHandler;
    Rigidbody2D rb;
    public float speed;
    private float startXPos;
    private float endXPos;
    private float time;
    public float fireRate = 2f;
    public int health;
    private int startingHealth;
    public GameObject healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponHandler = GetComponent<BasicWeaponHandler>();
        startXPos = transform.position.x;
        endXPos = startXPos - 10f;
        //Debug.Log(endXPos);
        startingHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        FirePlasmaGun();
        
    }
    public void SetHealth(int h)
    {
        health = h;
    }
    public int GetHealth()
    {
        return health;
    }
    private void FirePlasmaGun()
    {
        //maybe randomize the firerate ??
        time += Time.deltaTime;
        if(time >= fireRate)
        {
            weaponHandler.FireWeapon();
            time = 0f;
        }
    }
    public void PassPlayerObject(GameObject obj)
    {
        player = obj;
    }
    private void MoveLeft()
    {
        //maybe use this later to make a "Boss" type that stops and rapid fire shoots at the player?

        //float xPos = transform.position.x;
        //if(xPos >= endXPos)
        //{
        //    rb.linearVelocity = new Vector2(speed * -1, 0);
        //}
        //else
        //{
        //    rb.linearVelocity = new Vector2(0, 0);
        //}

        rb.linearVelocity = new Vector2(speed * -1, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Health = " + (health / startingHealth));
            health--;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
            healthBar.transform.localScale = new Vector3(((float)health / startingHealth), 1, 1);
        }
        else if(collision.gameObject.CompareTag("Missle"))
        {
            Destroy(gameObject);
        }
    }
}
