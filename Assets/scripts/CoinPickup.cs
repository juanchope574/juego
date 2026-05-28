using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Suma moneda
            CoinManager.instance.AddCoin();

            // Destruye moneda
            Destroy(gameObject);
        }
    }
}