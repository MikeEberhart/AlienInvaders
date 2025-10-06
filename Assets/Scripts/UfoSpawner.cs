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
    //private bool isSpawning;
    private float bTimer;
    private float sTimer;
    private float gTimer;
    public float spawnDelay;
    public float speedAdjustment;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        //bTimer += Time.deltaTime;
        //sTimer += Time.deltaTime;
        //gTimer += Time.deltaTime;
        time += Time.deltaTime;
        UfoSelector();
        // thought I could use spawnDelay to speed things up as time progressed
        // but this might cause issue if it becomes to fast because of how ufos are spanwed in
        // the image I made for the UFO.png causes extreme lag when the images overlap
        if (time >= spawnDelay)
        {
            bTimer++;
            sTimer++;
            gTimer++;
            //isSpawning = false;
            time = 0f;
        }

    }
    private void UfoSelector()
    {
        //bTimer += Time.deltaTime;
        //sTimer += Time.deltaTime;
        //gTimer += Time.deltaTime;
        if (gTimer >= Random.Range(goldCooldownMin, goldCooldownMax))// && !isSpawning)
        {
            SpawnUfo(ufoList[2]);
            gTimer = 0f;
            sTimer = 0f;
            bTimer = 0f;
            //isSpawning = true;
        }
        else if(sTimer >= Random.Range(silverCooldownMin, silverCooldownMax))// && !isSpawning)
        {
            SpawnUfo(ufoList[1]);
            sTimer = 0f;
            bTimer = 0f;
            //isSpawning = true;
        }
        else if(bTimer >= Random.Range(bronzeCooldownMin, bronzeCooldownMax))// && !isSpawning)
        {
            SpawnUfo(ufoList[0]);
            bTimer = 0f;
            //isSpawning = true;
        }
    }
    private void SpawnUfo(GameObject ufo)
    {
        spawnedUfo = Instantiate(ufo);
        spawnedUfo.GetComponent<UfoData>().SetUfoSpeed(speedAdjustment);
        spawnedUfo.transform.position = new Vector2(ufoLowerYSpawn.transform.position.x, Random.Range(ufoLowerYSpawn.transform.position.y, ufoUpperYSpawn.transform.position.y));

        //was used to pass the player object but probably dont need this now since im using a static var
        //spawnedUfo.GetComponent<UfoController>().PassPlayerObject(playerJet);
    }

}
