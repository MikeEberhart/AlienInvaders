using UnityEngine;

public class UfoController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private float startXPos;
    private float endXPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startXPos = transform.position.x;
        endXPos = startXPos - 10f;
        Debug.Log(endXPos);
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }
    private void UfoMovement()
    {

    }
    private void MoveLeft()
    {
        float xPos = transform.position.x;
        if(xPos >= endXPos)
        {
            rb.linearVelocity = new Vector2(speed * -1, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
    }
}
