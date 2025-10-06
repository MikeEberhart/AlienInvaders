using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject goldCoin;
    public GameObject leftXSpawn;
    public GameObject rightXSpawn;
    private GameObject spawnedCoin;
    private float time;
    public float delay;
    public float gravity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= delay)
        {
            SpawnCoin();
            time = 0f;
        }
    }

    private void SpawnCoin()
    {
        spawnedCoin = Instantiate(goldCoin);
        spawnedCoin.transform.position = new Vector2(Random.Range(leftXSpawn.transform.position.x, rightXSpawn.transform.position.x), leftXSpawn.transform.position.y);
        spawnedCoin.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

}
