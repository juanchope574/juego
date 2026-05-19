using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthSystem health = other.GetComponent<HealthSystem>();

            if (health != null)
            {
                health.InstantKill();
            }
        }
    }
}
