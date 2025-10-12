using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject upperYSpawn;
    public GameObject lowerYSpawn;
    public List<GameObject> powerUpList = new List<GameObject>();
    private GameObject spawnedPowerUp;
    private float spawnDelay;
    public float missleCooldown;
    public float shieldCooldown;
    public float starCooldown;
    private float time;
    private float mTimer;
    private float sTimer;
    private float starTimer;
    public float speedAdjustment;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mTimer = 0;
        sTimer = 0;
        starTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpSelector();
        time += Time.deltaTime;
        if(time >= spawnDelay)
        {
            mTimer++;
            sTimer++;
            starTimer++;
            time = 0f;
        }
    }

    private void PowerUpSelector()
    {
        if(starTimer >= starCooldown)
        {
            SpawnPowerUp(powerUpList[2]);
            mTimer = 0f;
            sTimer = 0f;
            starTimer = 0f;
        }
        else if(sTimer >= shieldCooldown)
        {
            SpawnPowerUp(powerUpList[1]);
            mTimer = 0f;
            sTimer = 0f;
        }
        else if (mTimer >= missleCooldown)
        {
            SpawnPowerUp(powerUpList[0]);
            mTimer = 0f;
        }
    }
    private void SpawnPowerUp(GameObject pUp)
    {
        spawnedPowerUp = Instantiate(pUp);
        spawnedPowerUp.GetComponent<PowerUpController>().SetPowerUpSpeed(speedAdjustment);
        spawnedPowerUp.transform.position = new Vector2(lowerYSpawn.transform.position.x, Random.Range(lowerYSpawn.transform.position.y, upperYSpawn.transform.position.y));
    }
    public void SetPowerUpSpawnDelay(float d)
    {
        spawnDelay = d;
    }
}
