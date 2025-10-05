using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class UfoData : MonoBehaviour
{
    private PlayerController pController;
    public float ufoStartingHealth;
    private float ufoCurrentHealth;
    public GameObject healthBar;
    public int ufoValue;
    public float fireRate;

    private void Start()
    {
        ufoCurrentHealth = ufoStartingHealth;
        pController = PlayerController.playerJet.GetComponent<PlayerController>();
    }
    public int GetUfoValue()
    {
        return ufoValue;
    }
    public void SetUfoValue(int value)
    {
        ufoValue = value;
    }
    public float GetUfoFireRate()
    {
        return fireRate;
    }
    public void SetUfoFireRate(float fRate)
    {
        fireRate = fRate;
    }
    public void DestoryUfo()
    {
        Destroy(gameObject);
    }
    public float GetUfoHealth()
    {
        return ufoCurrentHealth;
    }
    public void SetUfoHealth(float health)
    {
        ufoCurrentHealth = health;
    }
    public void UpdateHealthAfterDamage(float damageTaken)
    {
        ufoCurrentHealth -= damageTaken;
        if(ufoCurrentHealth <= 0)
        {
            pController.UpdatePlayerScore(ufoValue);
            DestoryUfo();
        }
        healthBar.transform.localScale = new Vector3((ufoCurrentHealth / ufoStartingHealth), 1, 1);
    }
}
