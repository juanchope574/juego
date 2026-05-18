using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        CargarPartida();
    }

    public void GuardarPartida()
    {
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.position.z);

        PlayerPrefs.Save();

        Debug.Log("Partida guardada");
    }

    public void CargarPartida()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            Vector3 posicionGuardada = new Vector3(
                PlayerPrefs.GetFloat("PlayerX"),
                PlayerPrefs.GetFloat("PlayerY"),
                PlayerPrefs.GetFloat("PlayerZ")
            );

            CharacterController controller = player.GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.enabled = false;
                player.position = posicionGuardada;
                controller.enabled = true;
            }
            else
            {
                player.position = posicionGuardada;
            }

            Debug.Log("Partida cargada");
        }
    }
}