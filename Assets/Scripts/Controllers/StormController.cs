using UnityEngine;

public class StormController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public float yMidPoint;
    private float movementDirection;
    public float limitDiff; //could be public and used to change/pass the var to change the limit params
    private float upperLimit;
    private float lowerLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementDirection = SetRandomDirection();
        upperLimit = yMidPoint + limitDiff;
        lowerLimit = yMidPoint - limitDiff;
        
    }

    // Update is called once per frame
    void Update()
    {
        //MoveLeft();
        StormMovement();
    }
    private int SetRandomDirection()
    {
        int ranNum = Random.Range(0, 2);
        if(ranNum == 0)
        {
            //even = 1
            return 1;
        }
        else //if(ranNum == 1)
        {
            //odd = -1
            return -1;
        }
    }
    private void StormMovement()
    {
        float yPos = transform.position.y;
        if(yPos >= upperLimit)
        {
            movementDirection = -1;
        }
        else if(yPos <= lowerLimit)
        {
            movementDirection = 1;
        }
        rb.linearVelocity = new Vector2(speed * -1, movementDirection * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjectBoundary"))
        {
            Destroy(this.gameObject);
        }
    }
}
