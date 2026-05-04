using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaActual;

    public Slider barraVida;

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
        Destroy(gameObject);
    }
}