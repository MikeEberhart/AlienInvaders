using UnityEngine;

public class UfoController : MonoBehaviour
{
    //private PlayerController pController;
    private UfoData ufoData;
    private BasicWeaponHandler weaponHandler;
    private Rigidbody2D rb;
    public float speed;
    private float startXPos;
    private float endXPos;
    private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponHandler = GetComponent<BasicWeaponHandler>();
        ufoData = GetComponent<UfoData>();
        startXPos = transform.position.x;
        endXPos = startXPos - 10f;
        //pController = PlayerController.playerJet.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        FirePlasmaGun();
        
    }
    private void FirePlasmaGun()
    {
        //maybe randomize the firerate ??
        time += Time.deltaTime;
        if(time >= ufoData.GetUfoFireRate())
        {
            weaponHandler.FireWeapon();
            time = 0f;
        }
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
            //update player score from ufo value
            int dmg = collision.gameObject.GetComponent<HorizontalFireControl>().GetWeaponDMG();
            ufoData.UpdateHealthAfterDamage(dmg);
        }
        else if(collision.gameObject.CompareTag("Missle"))
        {
            ufoData.UpdateHealthAfterDamage(ufoData.GetUfoHealth());
        }
        else if(collision.gameObject.CompareTag("ObjectBoundary"))
        {
            ufoData.DestoryUfo();
        }
    }
}
