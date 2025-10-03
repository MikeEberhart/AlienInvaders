using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class SpecialWeaponHandler : MonoBehaviour
{
    public GameObject missle;
    public GameObject nuke;
    public GameObject shields;
    public GameObject missleLauncher;
    public GameObject nukeLauncher;
    public GameObject shieldMount;
    private GameObject spawnedWeapon;
    //private float time;
    //private float 

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void FireMissle()
    {
        float xPos = missleLauncher.transform.position.x;
        float yPos = missleLauncher.transform.position.y;
        spawnedWeapon = Instantiate(missle);
        spawnedWeapon.transform.position = new Vector2(xPos, yPos);
    }

    //public void ShieldsOnline()
    //{
    //    Debug.Log("shields online");
    //    float xPos = shieldMount.transform.position.x;
    //    float yPos = shieldMount.transform.position.y;
    //    spawnedWeapon = Instantiate(shields);
    //    spawnedWeapon.transform.position = new Vector2(xPos, yPos);
    //    spawnedWeapon.transform.SetParent(shieldMount.transform);
    //}
}
