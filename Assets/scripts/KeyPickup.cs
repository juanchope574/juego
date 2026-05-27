using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Suma una llave
            KeyManager.instance.AddKey();

            // Destruye la llave
            Destroy(gameObject);
        }
    }
}