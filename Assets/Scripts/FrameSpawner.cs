using UnityEngine;

public class FrameSpawner : MonoBehaviour
{
    public GameObject movingRoad;
    public GameObject fSpawner;
    private float time;
    public float delay;
    private GameObject spawnedFrame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add to time. see how much time has passed since last frame
        time += Time.deltaTime;
        if (time >= delay)
        {
            SpawnFrame();
            //reset time so the bronzeUfoTimer is set for the next object to spawn
            time = 0f;
        }
    }

    private void SpawnFrame()
    {
        spawnedFrame = Instantiate(movingRoad);
        spawnedFrame.transform.position = fSpawner.transform.position;
    }
}
