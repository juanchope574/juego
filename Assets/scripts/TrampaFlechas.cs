using UnityEngine;

public class TrampaFlechas : MonoBehaviour
{
    public float alturaSubida = 2f;
    public float velocidad = 8f;
    public float tiempoEsperar = 2f;

    private Vector3 posicionInicial;
    private Vector3 posicionArriba;

    private bool subiendo = true;

    void Start()
    {
        posicionInicial = transform.position;

        posicionArriba = posicionInicial + Vector3.up * alturaSubida;

        InvokeRepeating("CambiarEstado", tiempoEsperar, tiempoEsperar);
    }

    void Update()
    {
        if (subiendo)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicionArriba,
                velocidad * Time.deltaTime
            );
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicionInicial,
                velocidad * Time.deltaTime
            );
        }
    }

    void CambiarEstado()
    {
        subiendo = !subiendo;
    }
}