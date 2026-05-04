using UnityEngine;

public class RecolectorLlaves : MonoBehaviour
{
    public int llavesRecolectadas = 0;

    public void AgregarLlave()
    {
        llavesRecolectadas++;
        Debug.Log("Llaves recolectadas: " + llavesRecolectadas);
    }

    public bool TieneTresLlaves()
    {
        return llavesRecolectadas >= 3;
    }
}