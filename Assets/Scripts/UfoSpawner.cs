using UnityEngine;

public class UfoSpawner : MonoBehaviour
{
    //public GameObject spawner;
    public GameObject ufo;
    private GameObject spawnedUfo;
    public GameObject ufoUpperYSpawn;
    public GameObject ufoLowerYSpawn;
    public GameObject playerJet;
    private float time;
    public float delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= delay)
        {
            SpawnUfo();
            time = 0f;
        }
    }

    private void SpawnUfo()
    {
        spawnedUfo = Instantiate(ufo);
        spawnedUfo.transform.position = new Vector2(ufoLowerYSpawn.transform.position.x, Random.Range(ufoLowerYSpawn.transform.position.y, ufoUpperYSpawn.transform.position.y));
        spawnedUfo.GetComponent<UfoController>().PassPlayerObject(playerJet);
    }
}
