using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public MonoBehaviour playerController;
    public HealthSystem playerHealth;
    public Transform checkpoint;

    public void ActivarGameOver()
    {
        playerController.enabled = false;

        panelGameOver.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;

        panelGameOver.SetActive(false);

        playerHealth.Respawn(checkpoint.position);

        playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

       //SceneManagement.SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    void Start()
    {
        panelGameOver.SetActive(false);
    }
}
