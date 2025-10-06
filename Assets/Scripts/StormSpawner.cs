using UnityEngine;

public class StormSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject stormClouds;
    private float time;
    public float delay;
    private GameObject spawnedStorm;
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
            SpawnStorm();
            //reset time so the bronzeUfoTimer is set for the next object to spawn
            time = 0f;
        }
    }

    private void SpawnStorm()
    {
        spawnedStorm = Instantiate(stormClouds);
        StormController sc = spawnedStorm.GetComponent<StormController>();
        sc.yMidPoint = this.transform.position.y;
        //Debug.Log("ypos = " + this.transform.position.y);
        spawnedStorm.transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
    }
}
