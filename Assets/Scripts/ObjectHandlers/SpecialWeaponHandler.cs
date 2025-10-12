using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialWeaponHandler : MonoBehaviour
{
    public GameObject missle;
    public GameObject missleLauncher;
    private GameObject spawnedWeapon;

    public void FireMissle()
    {
        float xPos = missleLauncher.transform.position.x;
        float yPos = missleLauncher.transform.position.y;
        spawnedWeapon = Instantiate(missle);
        spawnedWeapon.transform.position = new Vector2(xPos, yPos);
    }
}
