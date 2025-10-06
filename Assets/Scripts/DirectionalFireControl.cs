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
        rb = GetComponent<Rigidbody2D>();
        playerPos = (PlayerController.playerJet.transform.position - transform.position).normalized;
        //transform.LookAt(playerPos);
        transform.right = playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(playerPos * speed);
    }
    //is passing it through scripts better than using the public static var
    //public void PassPlayerObj(GameObject obj)
    //{
    //    player = obj;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}


//player = GetComponent<GameObject>();
//playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
//player = gameObject.
//transform.rotation = Quaternion.LookRotation(playerPos);
