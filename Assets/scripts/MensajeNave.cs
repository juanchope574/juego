using UnityEngine;

public class MensajeNave : MonoBehaviour
{
    [Header("Mensaje UI")]
    public GameObject mensajeUI;

    private void Start()
    {
        // Oculta el mensaje al iniciar
        mensajeUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta al jugador
        if (other.CompareTag("Player"))
        {
            mensajeUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Oculta el mensaje cuando se aleje
        if (other.CompareTag("Player"))
        {
            mensajeUI.SetActive(false);
        }
    }
}