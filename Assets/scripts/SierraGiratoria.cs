using UnityEngine;

public class SierraGiratoria : MonoBehaviour
{
    public float velocidadGiro = 700f;
    public int danio = 10;
    public float tiempoEntreDanios = 1f;

    private float siguienteDanio = 0f;

    void Update()
    {
       transform.Rotate(0f, 0f, velocidadGiro * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= siguienteDanio)
            {
                HealthSystem vida = other.GetComponent<HealthSystem>();

                if (vida != null)
                {
                    vida.TakeDamage(danio);
                    Debug.Log("La sierra hizo daño");
                }

                siguienteDanio = Time.time + tiempoEntreDanios;
            }
        }
    }
}