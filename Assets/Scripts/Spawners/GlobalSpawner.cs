using UnityEngine;

public class GlobalSpawner : MonoBehaviour
{
    public GameObject buildingSpawner;
    public GameObject cloudSpawner;
    public GameObject ufoSpawner;
    public GameObject powerUpSpawner;
    public GameObject coinSpawner;
    public float buildingDelayStart;
    public float stormDelayStart;
    public float ufoDelayStart;
    public float powerUpDelayStart;
    public float coinDelayStart;
    public float bChangeDelayCounter;
    public float uChangeDelayCounter;
    public float cChangeDelayCounter;
    private float time;
    private float buildTimer;
    private float ufoTimer;
    private float coinTimer;

    //use this to control all the spawners so after every 30 seconds or a min
    //the delays are decrease causing more things to spawning making it "harder"

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildTimer = 0f;
        ufoTimer = 0f;
        coinTimer = 0f;
        buildingSpawner.GetComponent<BuildingSpawner>().SetBuildingSpawnDelay(buildingDelayStart);
        cloudSpawner.GetComponent<StormSpawner>().SetStormSpawnDelay(stormDelayStart);
        ufoSpawner.GetComponent<UfoSpawner>().SetUfoSpawnDelay(ufoDelayStart);
        powerUpSpawner.GetComponent<PowerUpSpawner>().SetPowerUpSpawnDelay(powerUpDelayStart);
        coinSpawner.GetComponent<CoinSpawner>().SetCoinDelay(coinDelayStart);
        powerUpSpawner.transform.position = new Vector2(18.924f, powerUpSpawner.gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1f)
        {
            buildTimer++;
            ufoTimer++;
            coinTimer++;
            if (buildTimer >= bChangeDelayCounter)
            {
                buildingSpawner.GetComponent<BuildingSpawner>().SetBuildingSpawnDelay(2);
                powerUpSpawner.transform.position = new Vector2(17f, powerUpSpawner.gameObject.transform.position.y);
                buildTimer = 0f;
            }
            if (ufoTimer >= uChangeDelayCounter && ufoDelayStart >= .5f)
            {
                ufoDelayStart = ufoDelayStart - .1f;
                ufoSpawner.GetComponent<UfoSpawner>().SetUfoSpawnDelay(ufoDelayStart);
                ufoTimer = 0f;
            }
            if (coinTimer >= cChangeDelayCounter && coinDelayStart >= .5f)
            {
                coinDelayStart = coinDelayStart - .5f;
                coinSpawner.GetComponent<CoinSpawner>().SetCoinDelay(coinDelayStart);
                coinTimer = 0f;
            }
            time = 0f;
        }    
    }
}
