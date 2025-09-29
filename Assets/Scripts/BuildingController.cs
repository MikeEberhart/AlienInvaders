using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public float speed = 1.0f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }
     private void moveLeft()
    {
        rb.linearVelocity = new Vector2(speed * -1, 0);
    }
}
