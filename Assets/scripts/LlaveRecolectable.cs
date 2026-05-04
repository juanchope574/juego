using UnityEngine;

public class LlaveRecolectable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RecolectorLlaves recolector = other.GetComponent<RecolectorLlaves>();

            if (recolector != null)
            {
                recolector.AgregarLlave();
                Destroy(gameObject);
            }
        }
    }
}