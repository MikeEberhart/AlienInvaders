using UnityEngine;

public class DirectionalFireControl : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public GameObject player;
    private Vector2 playerPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //with a little help from stack overflow I was able to get this working correctly
        //script is used to fire plasma shots from the UFO at the playerJet
        rb = GetComponent<Rigidbody2D>();
        playerPos = (PlayerController.playerJet.transform.position - transform.position).normalized;
        transform.right = playerPos;
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(playerPos * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }
}

