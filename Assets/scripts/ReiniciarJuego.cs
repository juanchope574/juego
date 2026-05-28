using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour
{
    public SaveSystem saveSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            saveSystem.BorrarPartida();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}