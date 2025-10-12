using UnityEngine;
using UnityEngine.UIElements;

public class BasicWeaponHandler : MonoBehaviour
{
    public GameObject defaultWeapon;
    public GameObject weaponBarrel;
    private GameObject spawnedWeapon;
    private GameObject playerJet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void FireWeapon()
    {
        float xPos = weaponBarrel.transform.position.x;
        float yPos = weaponBarrel.transform.position.y;
        if(gameObject.CompareTag("Player"))
        {
            spawnedWeapon = Instantiate(defaultWeapon);
            spawnedWeapon.transform.position = new Vector2(xPos, yPos);
            //Debug.Log(playerJet.name);
        }
        else if(gameObject.CompareTag("UFO"))
        {
            spawnedWeapon = Instantiate(defaultWeapon);
            spawnedWeapon.transform.position = new Vector2(xPos, yPos);
        }
    }
}
