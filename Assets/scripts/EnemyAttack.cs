using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float tiempoEntreAtaques = 1.5f;

    private float siguienteAtaque;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= siguienteAtaque)
        {
            HealthSystem health = other.GetComponent<HealthSystem>();

            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("Enemigo hizo daño");
            }

            siguienteAtaque = Time.time + tiempoEntreAtaques;
        }
    }
}