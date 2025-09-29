using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject sBuilding;
    public GameObject mBuilding;
    public GameObject lBuilding;
    public GameObject leftSpawn;
    //public GameObject rightSpawn;
    private GameObject building01;
    //private GameObject building02;
    private int randomBuilding01;
    private int randomBuilding02;
    private float time;
    public float delay;
    private float yVal;
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
            //spawn the building
            SpawnBuilding();
            //resets the delay for the next building
            time = 0f;
        }
    }

    //private void SpawnBuilding()
    //{
    //    LeftSpawner();
    //    //RightSpawner();
    //}

    private void SpawnBuilding()
    {
        randomBuilding01 = Random.Range(0, 3);
        //float yVal;
        Debug.Log(randomBuilding01);
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
        else if(randomBuilding01 ==2 )
        {
            yVal = -1.74f;
            building01 = Instantiate(lBuilding);
        }
        building01.transform.position = new Vector2(leftSpawn.transform.position.x, yVal);
    }

    //private void RightSpawner()
    //{
    //    randomBuilding02 = Random.Range(0, 3);
    //    Debug.Log(randomBuilding02);
    //    if(randomBuilding02 == 0)
    //    {
    //        building02 = Instantiate(sBuilding);
    //    }
    //    else if(randomBuilding02 == 1)
    //    {
    //        building02 = Instantiate(mBuilding);
    //    }
    //    else if(randomBuilding02 == 2)
    //    {
    //        building02 = Instantiate(lBuilding);
    //    }
    //    building02.transform.position = new Vector2(rightSpawn.transform.position.x, rightSpawn.transform.position.y);
    //}
}
