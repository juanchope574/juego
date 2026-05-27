using UnityEngine;

public class IceBallDamage : MonoBehaviour
{
    public int damage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("La bola chocó con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();

            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("La bola hizo daño");
            }
        }

        Destroy(gameObject);
    }
}