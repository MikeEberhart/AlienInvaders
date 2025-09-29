using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject shields;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shields.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if(Input.GetKeyDown(KeyCode.T))
        {
            //something like this but needs a bool to check if the player has the power up
            shields.SetActive(true);
        }
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
