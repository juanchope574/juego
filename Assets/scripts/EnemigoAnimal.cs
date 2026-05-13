using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemigoAnimal : MonoBehaviour
{
    public Transform jugador;

    public float distanciaDeteccion = 200f;

    private NavMeshAgent agente;
    private Animator animator;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        if (jugador == null)
        {
            GameObject objetoJugador = GameObject.FindGameObjectWithTag("Player");

            if (objetoJugador != null)
            {
                jugador = objetoJugador.transform;
            }
        }

        agente.isStopped = true;

        if (animator != null)
        {
            animator.SetBool("Walking", false);
        }
    }

    void Update()
    {
        if (jugador == null)
        {
            return;
        }

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaDeteccion)
        {
            agente.isStopped = false;
            agente.SetDestination(jugador.position);

            if (animator != null)
            {
                animator.SetBool("Walking", true);
            }
        }
        else
        {
            agente.isStopped = true;
            agente.ResetPath();

            if (animator != null)
            {
                animator.SetBool("Walking", false);
            }
        }
    }
}