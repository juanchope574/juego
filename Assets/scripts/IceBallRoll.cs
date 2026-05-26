using UnityEngine;

public class IceBallRoll : MonoBehaviour
{
    public float fuerzaInicial = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * fuerzaInicial, ForceMode.Impulse);
    }
}