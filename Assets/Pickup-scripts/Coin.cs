using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinSystem.instance.AddCoins(value);
            Destroy(gameObject);
        }
    }
}