using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public GameObject camaraMenu;
    public GameObject camaraJuego;
    public GameObject panelMenu;
    public GameObject creditosPanel;

    public GameObject menuPrincipal;

    public GameObject jugador;
    public MonoBehaviour playerController; // arrastraremos el script aquí

    //OSCURECIMIENTO de la camara
    public Image fadeImage;
    public float fadeSpeed = 2f;

    void Start()
    {
        camaraMenu.SetActive(true);
        camaraJuego.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void IniciarJuego()
    {
        Time.timeScale = 1f; //este elemento es para que vuelva a hacer usable el boton de pausa

        panelMenu.SetActive(false);

        camaraMenu.SetActive(false);
        camaraJuego.SetActive(true);

        playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("Botón presionado");

        StartCoroutine(FadeAndStart());

        Debug.Log("Botón presionado");

        // Desactivar menú visual
        if (panelMenu != null)
            panelMenu.SetActive(false);

        // Desactivar cámara del menú
        if (camaraMenu != null)
            camaraMenu.SetActive(false);

        // Activar cámara del juego
        if (camaraJuego != null)
            camaraJuego.SetActive(true);

        // Asegurar que el tiempo esté normal
        Time.timeScale = 1f;
    }

    IEnumerator FadeAndStart()
    {
        float alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        panelMenu.SetActive(false);

        camaraMenu.SetActive(false);
        camaraJuego.SetActive(true);

        playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AbrirCreditos()
    {
        creditosPanel.SetActive(true);

        menuPrincipal.SetActive(false);
    }

    public void CerrarCreditos()
    {
        creditosPanel.SetActive(false);

        menuPrincipal.SetActive(true);
    }
}