using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject sBuilding;
    public GameObject mBuilding;
    public GameObject lBuilding;
    public GameObject leftSpawn;
    private GameObject building01;
    private int randomBuilding01;
    private float time;
    private float delay;
    private float yVal;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= delay)
        {
            //spawn the building
            SpawnBuilding();
            time = 0f;
        }
    }
    private void SpawnBuilding()
    {
        randomBuilding01 = Random.Range(0, 3);
        //Debug.Log(randomBuilding01);
        if(randomBuilding01 == 0)
        {
            yVal = -2.62f;
            building01 = Instantiate(sBuilding);
        }
        else if(randomBuilding01 == 1)
        {
            yVal = -2.25f;
            building01 = Instantiate(mBuilding);
        }
        else if(randomBuilding01 == 2 )
        {
            yVal = -1.74f;
            building01 = Instantiate(lBuilding);
        }
        building01.transform.position = new Vector2(leftSpawn.transform.position.x, yVal);
    }
    public void SetBuildingSpawnDelay(float d)
    {
        delay = d;
    }
}
