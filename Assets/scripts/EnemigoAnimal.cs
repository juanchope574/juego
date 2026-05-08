using UnityEngine;
using UnityEngine.AI;

public class EnemigoAnimal : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform jugador;

    [Header("Distancias")]
    public float distanciaDeteccion = 200f;
    public float distanciaAtaque = 3f;

    [Header("Daño")]
    public int daño = 10;
    public float tiempoEntreAtaques = 1.5f;

    [Header("Movimiento")]
    public float velocidad = 12f;
    public float aceleracion = 30f;
    public float velocidadAngular = 500f;

    private NavMeshAgent agente;
    private float tiempoSiguienteAtaque;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        // CONFIGURACIÓN DE VELOCIDAD
        agente.speed = velocidad;
        agente.acceleration = aceleracion;
        agente.angularSpeed = velocidadAngular;

        if (jugador == null)
        {
            GameObject objetoJugador = GameObject.FindGameObjectWithTag("Player");

            if (objetoJugador != null)
            {
                jugador = objetoJugador.transform;
            }
        }
    }

    void Update()
    {
        if (jugador == null)
        {
            Debug.Log("No se encontró el jugador. Revisa que tenga Tag Player.");
            return;
        }

        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        Debug.Log("Distancia al jugador: " + distanciaAlJugador);

        if (distanciaAlJugador <= distanciaDeteccion)
        {
            if (distanciaAlJugador > distanciaAtaque)
            {
                SeguirJugador();
            }
            else
            {
                AtacarJugador();
            }
        }
        else
        {
            DetenerEnemigo();
        }
    }

    void SeguirJugador()
    {
        agente.isStopped = false;
        agente.SetDestination(jugador.position);
    }

    void AtacarJugador()
    {
        agente.isStopped = true;

        Vector3 posicionMirar = new Vector3(
            jugador.position.x,
            transform.position.y,
            jugador.position.z
        );

        transform.LookAt(posicionMirar);

        if (Time.time >= tiempoSiguienteAtaque)
        {
            HealthSystem vidaJugador = jugador.GetComponent<HealthSystem>();

            if (vidaJugador != null)
            {
                vidaJugador.TakeDamage(daño);
            }

            tiempoSiguienteAtaque = Time.time + tiempoEntreAtaques;
        }
    }

    void DetenerEnemigo()
    {
        agente.isStopped = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDeteccion);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }
}