using UnityEngine;

public class BarricadaPuerta : MonoBehaviour
{
    public static BarricadaPuerta instancia;

    public int animalesRecolectados = 0;

    public GameObject puerta;

    void Awake()
    {
        instancia = this;
    }

    public void RecolectarAnimal()
    {
        animalesRecolectados++;

        Debug.Log("Animales recolectados: " + animalesRecolectados);

        if (animalesRecolectados >= 3)
        {
            Destroy(puerta);

            Debug.Log("La puerta desapareció");
        }
    }
}