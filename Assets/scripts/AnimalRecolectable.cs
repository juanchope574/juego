using UnityEngine;

public class AnimalRecolectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BarricadaPuerta.instancia.RecolectarAnimal();

            Destroy(gameObject);
        }
    }
}