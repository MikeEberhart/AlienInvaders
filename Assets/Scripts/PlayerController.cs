using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
        float yPos = Input.GetAxisRaw("Vertical");
        //Vector3 pMove = new Vector3(xPos, yPos, 0).normalized;
        //transform.position += pMove * speed * Time.deltaTime;
        //rb.linearVelocity = new Vector2(xPos * speed, yPos * speed);
        Vector2 pMove = new Vector2(xPos, yPos).normalized;
        rb.linearVelocity = pMove * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Boundary"))
        {
            Debug.Log("Game Over");
        }
    }
}
