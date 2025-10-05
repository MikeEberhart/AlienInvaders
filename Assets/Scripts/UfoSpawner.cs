using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class UfoSpawner : MonoBehaviour
{
    //public GameObject spawner;
    public List<GameObject> ufoList = new List<GameObject>();
    //public GameObject bronzeUFO;
    //public GameObject silverUFO;
    //public GameObject goldUFO;
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
        spawnedUfo = Instantiate(ufoList[Random.Range(0,3)]);
        spawnedUfo.transform.position = new Vector2(ufoLowerYSpawn.transform.position.x, Random.Range(ufoLowerYSpawn.transform.position.y, ufoUpperYSpawn.transform.position.y));
        
        //was used to pass the player object but probably dont need this now
        //spawnedUfo.GetComponent<UfoController>().PassPlayerObject(playerJet);
    }
}
