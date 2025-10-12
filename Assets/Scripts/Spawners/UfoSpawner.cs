using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class UfoSpawner : MonoBehaviour
{
    public List<GameObject> ufoList = new List<GameObject>();
    private GameObject spawnedUfo;
    public GameObject ufoUpperYSpawn;
    public GameObject ufoLowerYSpawn;
    public GameObject playerJet;
    private float time;
    public float bronzeCooldownMin;
    public float bronzeCooldownMax;
    public float silverCooldownMin;
    public float silverCooldownMax;
    public float goldCooldownMin;
    public float goldCooldownMax;
    private float bTimer;
    private float sTimer;
    private float gTimer;
    private float spawnDelay;
    public float speedAdjustment;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bTimer = 0;
        sTimer = 0;
        gTimer = 0;
        spawnDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        UfoSelector();
        // was thinking I could use spawnDelay to speed things up as time progressed
        // but this might cause issue if it becomes to fast because of how ufos are spanwed in
        // the image I made for the UFO.png causes extreme lag when the images overlap
        if (time >= spawnDelay)
        {
            bTimer++;
            sTimer++;
            gTimer++;
            time = 0f;
        }

    }
    private void UfoSelector()
    {
        if (gTimer >= Random.Range(goldCooldownMin, goldCooldownMax))
        {
            SpawnUfo(ufoList[2]);
            gTimer = 0f;
            sTimer = 0f;
            bTimer = 0f;
        }
        else if(sTimer >= Random.Range(silverCooldownMin, silverCooldownMax))
        {
            SpawnUfo(ufoList[1]);
            sTimer = 0f;
            bTimer = 0f;
        }
        else if(bTimer >= Random.Range(bronzeCooldownMin, bronzeCooldownMax))
        {
            SpawnUfo(ufoList[0]);
            bTimer = 0f;
        }
    }
    private void SpawnUfo(GameObject ufo)
    {
        spawnedUfo = Instantiate(ufo);
        spawnedUfo.GetComponent<UfoData>().SetUfoSpeed(speedAdjustment);
        spawnedUfo.transform.position = new Vector2(ufoLowerYSpawn.transform.position.x, Random.Range(ufoLowerYSpawn.transform.position.y, ufoUpperYSpawn.transform.position.y));
    }
    public void SetUfoSpawnDelay(float d)
    {
        spawnDelay = d;
    }
}
