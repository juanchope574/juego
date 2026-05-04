using UnityEngine;
using UnityEngine.AI;

public enum EstadoZombie
{
    quieto,
    perseguir,
    atacar
}

public class ZerebroEnemigo : MonoBehaviour
{
    public EstadoZombie estadoActual = EstadoZombie.quieto;

    public GameObject jugador;

    public float distanciaDeteccion = 15f;
    public float distanciaAtaque = 2f;

    public float tiempoEntreAtaques = 2f;

    private float relojAtaque = 0;

    private MovimientoEnemigo movimiento;
    private Animator animator;
    private NavMeshAgent agente;

    void Start()
    {
        movimiento = GetComponent<MovimientoEnemigo>();
        animator = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (jugador == null) return;

        float distanciaJugador = Vector3.Distance(transform.position, jugador.transform.position);

        relojAtaque += Time.deltaTime;

        switch (estadoActual)
        {
            case EstadoZombie.quieto:
                EstadoQuieto(distanciaJugador);
                break;

            case EstadoZombie.perseguir:
                EstadoPerseguir(distanciaJugador);
                break;

            case EstadoZombie.atacar:
                EstadoAtacar(distanciaJugador);
                break;
        }
    }

    void EstadoQuieto(float distancia)
    {
        animator.SetBool("Walk", false);
        movimiento.a_quien_seguir = null;
        agente.isStopped = true;

        if (distancia <= distanciaDeteccion)
        {
            estadoActual = EstadoZombie.perseguir;
        }
    }

    void EstadoPerseguir(float distancia)
    {
        animator.SetBool("Walk", true);

        agente.isStopped = false;
        movimiento.a_quien_seguir = jugador;

        if (distancia <= distanciaAtaque)
        {
            estadoActual = EstadoZombie.atacar;
        }

        if (distancia > distanciaDeteccion)
        {
            estadoActual = EstadoZombie.quieto;
        }
    }

    void EstadoAtacar(float distancia)
    {
        movimiento.a_quien_seguir = null;

        agente.isStopped = true;

        animator.SetBool("Walk", false);

        if (relojAtaque >= tiempoEntreAtaques)
        {
            animator.SetTrigger("Attack");
            relojAtaque = 0;
        }

        if (distancia > distanciaAtaque)
        {
            agente.isStopped = false;
            estadoActual = EstadoZombie.perseguir;
        }
    }
}