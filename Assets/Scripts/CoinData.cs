using UnityEngine;

public class CoinData : MonoBehaviour
{
    public int coinValue;
    public float speed;

    public float GetCoinSpeed()
    {
        return speed;
    }
    public int GetCoinValue()
    {
        return coinValue;
    }
    public void DestoryCoin()
    {
        Destroy(gameObject);
    }
}
