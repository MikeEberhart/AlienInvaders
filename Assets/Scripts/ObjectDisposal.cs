using UnityEngine;

public class ObjectDisposal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //game over
            Debug.Log("Game Over!!");
        }
        else if(collision.gameObject.CompareTag("Building"))
        {
            //if(this.gameObject.transform.name == "RightLimit")
            //{
            //    Debug.Log("RightLimit");
            //    Destroy(collision.gameObject);
            //}
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
