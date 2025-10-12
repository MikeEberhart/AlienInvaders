using UnityEngine;

public class HorizontalFireControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private int weaponDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //script is used by the player to fire bullets and missles 
        rb = GetComponent<Rigidbody2D>();
        weaponDamage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TravelRight();
    }
    public void SetWeaponDMG(int wDMG)
    {
        weaponDamage = wDMG;
    }
    public int GetWeaponDMG()
    {
        return weaponDamage;
    }
    private void TravelRight()
    {
        rb.linearVelocity = new Vector2(speed * 1, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("UFO"))
        {
            Destroy(gameObject);
        }
    }
}
