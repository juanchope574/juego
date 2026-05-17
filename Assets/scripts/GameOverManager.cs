using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public MonoBehaviour playerController;

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
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void VolverMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    void Start()
    {
        panelGameOver.SetActive(false);
    }
}
