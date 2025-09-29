using UnityEngine;

public class FrameController : MonoBehaviour
{
    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
