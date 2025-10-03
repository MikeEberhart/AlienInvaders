using UnityEngine;

public class HorizontalFireControl : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    //private float time;
    //public float fireRate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TravelRight();
    }
    private void TravelRight()
    {
        rb.linearVelocity = new Vector2(speed * 1, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ObjectBoundary"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("UFO"))
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
        //else if(collision.gameObject.CompareTag("RightObjBoundary"))
        //{
        //    Destroy(gameObject);
        //}
        //else if(collision.gameObject.CompareTag("PlasmaShot"))
        //{
        //    Destroy(gameObject);
        //    Destroy(collision.gameObject);
        //}
    }
}
