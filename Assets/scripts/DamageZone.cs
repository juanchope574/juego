using UnityEngine;

public class SnowBallDamage : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthSystem health = other.GetComponent<HealthSystem>();

            if (health != null)
            {
                health.TakeDamage(damage);

                Debug.Log("Daño aplicado");
            }
        }
    }
}