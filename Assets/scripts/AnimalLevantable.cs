using UnityEngine;

public class AnimalLevantable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Suma animal
            MundoAnimalDos.instance.AddAnimal();

            // Destruye animal
            Destroy(gameObject);
        }
    }
}