using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private CoinData cData;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cData = GetComponent<CoinData>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }
    private void MoveDown()
    {
        rb.linearVelocity = new Vector2(0, cData.GetCoinSpeed() * -1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ObjectBoundary"))
        {
            Destroy(gameObject);
        }
    }
}
