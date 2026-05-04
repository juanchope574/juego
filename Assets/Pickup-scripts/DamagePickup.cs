using UnityEngine;

public class DamagePickup : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        HealthSystem health = other.GetComponent<HealthSystem>();

        if (health != null)
        {
            health.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
