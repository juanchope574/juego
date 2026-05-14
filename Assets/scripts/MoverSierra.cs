using UnityEngine;

public class MoverSierra : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 3f;

    private Vector3 objetivo;

    void Start()
    {
        objetivo = puntoB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivo) < 0.1f)
        {
            if (objetivo == puntoA.position)
            {
                objetivo = puntoB.position;
            }
            else
            {
                objetivo = puntoA.position;
            }
        }
    }
}