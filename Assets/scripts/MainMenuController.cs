using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public GameObject camaraMenu;
    public GameObject camaraJuego;
    public GameObject panelMenu;

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
        panelMenu.SetActive(false);

        camaraMenu.SetActive(false);
        camaraJuego.SetActive(true);

        playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("Botón presionado");

        StartCoroutine(FadeAndStart());
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
}