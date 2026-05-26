using UnityEngine;

public class PuertaBloqueada : MonoBehaviour
{
    public void AbrirPuerta()
    {
        Debug.Log("Puerta abierta");

        // Destruye la puerta
        Destroy(gameObject);
    }
}