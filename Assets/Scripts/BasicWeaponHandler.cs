using UnityEngine;
using UnityEngine.UIElements;

public class BasicWeaponHandler : MonoBehaviour
{
    public GameObject defaultWeapon;
    public GameObject weaponBarrel;
    private GameObject spawnedWeapon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void FireWeapon()
    {
        float xPos = weaponBarrel.transform.position.x;
        float yPos = weaponBarrel.transform.position.y;
        spawnedWeapon = Instantiate(defaultWeapon);
        spawnedWeapon.transform.position = new Vector2(xPos, yPos);
    }
}
