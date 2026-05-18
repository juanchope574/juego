using UnityEngine;

public class CuboGuardado : MonoBehaviour
{
    public SaveSystem saveSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            saveSystem.GuardarPartida();
            Debug.Log("Tocaste el cubo de guardado");
        }
    }
}