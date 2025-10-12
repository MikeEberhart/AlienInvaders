using UnityEngine;

public class StormSpawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject stormClouds;
    private float time;
    private float delay;
    private GameObject spawnedStorm;
    public float spawnInterval;

    // Update is called once per frame
    void Update()
    {
        //used to delay the start of the spawn cycle
        delay -= Time.deltaTime;
        if(delay <= 0 )
        {
            time += Time.deltaTime;
            if (time >= spawnInterval)
            {
                SpawnStorm();
                //reset time so the bronzeUfoTimer is set for the next object to spawn
                time = 0f;
            }
        }

    }
    private void SpawnStorm()
    {
        spawnedStorm = Instantiate(stormClouds);
        StormController sc = spawnedStorm.GetComponent<StormController>();
        sc.yMidPoint = this.transform.position.y;
        //Debug.Log("ypos = " + transform.position.y);
        spawnedStorm.transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
    }
    public void SetStormSpawnDelay(float d)
    {
        delay = d;
    }
}
