
using UnityEngine;

public class RecolectorLlaves : MonoBehaviour
{
    public int llaves = 0;

    // Referencia a la puerta
    public PuertaBloqueada puerta;

    public void AgregarLlave()
    {
        llaves++;

        Debug.Log("Llaves recogidas: " + llaves);

        // Si tiene 3 llaves abre la puerta
        if (llaves >= 3)
        {
            puerta.AbrirPuerta();
        }
    }
}