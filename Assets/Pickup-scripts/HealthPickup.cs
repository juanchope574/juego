using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        HealthSystem health = other.GetComponent<HealthSystem>();

        if (health != null)
        {
            health.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
