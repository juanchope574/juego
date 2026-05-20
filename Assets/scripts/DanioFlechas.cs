using UnityEngine;

public class DanioFlechas : MonoBehaviour
{
    public int danio = 20;
    public float tiempoEntreDanio = 1f;

    private float siguienteDanio = 0f;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Tocando: " + other.name);

        if (other.CompareTag("Player") && Time.time >= siguienteDanio)
        {
            HealthSystem vida = other.GetComponent<HealthSystem>();

            if (vida != null)
            {
                vida.TakeDamage(danio);
                Debug.Log("Las flechas hicieron daño");
                siguienteDanio = Time.time + tiempoEntreDanio;
            }
            else
            {
                Debug.Log("El Player no tiene HealthSystem");
            }
        }
    }
}