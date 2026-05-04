using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovimientoEnemigo : MonoBehaviour
{
    [HideInInspector]
    public GameObject a_quien_seguir;

    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (a_quien_seguir != null && !agente.isStopped)
        {
            agente.SetDestination(a_quien_seguir.transform.position);
        }
    }
}