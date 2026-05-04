using UnityEngine;

public class PuertaSecreta : MonoBehaviour
{
    public GameObject puerta;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RecolectorLlaves recolector = other.GetComponent<RecolectorLlaves>();

            if (recolector != null && recolector.TieneTresLlaves())
            {
                puerta.SetActive(false);
                Debug.Log("Puerta secreta abierta");
            }
            else
            {
                Debug.Log("Necesitas 3 llaves para abrir esta puerta");
            }
        }
    }
}