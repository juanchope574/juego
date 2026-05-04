using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public int danio = 25;

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemigo = other.GetComponentInParent<EnemyHealth>();

        if (enemigo != null)
        {
            enemigo.RecibirDanio(danio);
            Debug.Log("Golpeando enemigo");
        }
    }
}