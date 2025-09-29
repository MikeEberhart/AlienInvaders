using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float offset;
    private Vector2 startPos;
    private float newXpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        newXpos = Mathf.Repeat(Time.time * -moveSpeed, offset);
        transform.position = startPos + Vector2.right * newXpos;
        
    }
}
