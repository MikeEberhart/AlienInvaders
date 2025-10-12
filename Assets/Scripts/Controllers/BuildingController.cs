using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }
    public void SetBuildingSpeed(float s)
    {
        speed = s;
    }
    private void MoveLeft()
    {
        rb.linearVelocity = new Vector2(speed * -1, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObjectBoundary"))
        {
            Destroy(this.gameObject);
        }
    }
}
