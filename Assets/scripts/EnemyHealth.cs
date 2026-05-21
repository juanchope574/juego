using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;

    public Slider barraVida;

    public GameObject puerta;

    void Start()
    {
        vidaActual = vidaMaxima;

        barraVida.maxValue = vidaMaxima;
        barraVida.value = vidaActual;
    }

    public void RecibirDanio(int danio)
    {
        vidaActual -= danio;

        barraVida.value = vidaActual;

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

  void Morir()
{
    Debug.Log("El enemigo murió");

    if (puerta != null)
    {
        Debug.Log("Sí encontró la puerta");
        puerta.SetActive(false);
    }
    else
    {
        Debug.Log("NO hay puerta asignada en el Inspector");
    }

    Destroy(gameObject);
}
}