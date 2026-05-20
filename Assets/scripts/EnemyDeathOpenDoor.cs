using UnityEngine;

public class EnemyDeathOpenDoor : MonoBehaviour
{
    public GameObject puerta;

    public void AbrirPuerta()
    {
        if (puerta != null)
        {
            puerta.SetActive(false);
            Debug.Log("Puerta abierta porque el enemigo murió");
        }
    }
}