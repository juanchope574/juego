using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Slider healthSlider;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        Debug.Log("Jugador vida: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthSlider != null)
            healthSlider.value = currentHealth;
    }

    void Die()
    {
        isDead = true;

        Debug.Log("Jugador murió");

        // Desactivar movimiento (si tienes script de movimiento)
        //GetComponent<PlayerMovement>().enabled = false;

        // Opción 1: Reiniciar escena
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Opción 2: Solo desactivar jugador
        //gameObject.SetActive(false);

        // Desactivar control del jugador
        GetComponent<PlayerController>().enabled = false;

        // Llamar al GameOverManager
        GameOverManager gm = FindFirstObjectByType<GameOverManager>();

        if (gm != null)
        {
            Debug.Log("GameOverManager encontrado");
            gm.ActivarGameOver();
        }
        else
        {
            Debug.Log("NO se encontró GameOverManager");
        }
    }

    public void InstantKill()
    {
        currentHealth = 0;
        Die();
    }

    public void Respawn(Vector3 checkpointPosition)
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        transform.position = checkpointPosition;

        gameObject.SetActive(true);

        isDead = false;
    }
}