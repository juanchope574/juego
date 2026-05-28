using UnityEngine;

public class MundoAnimalDos : MonoBehaviour
{
    public static MundoAnimalDos instance;

    [Header("Cantidad de animales")]
    public int animales = 0;

    [Header("Puerta a desbloquear")]
    public GameObject puerta;

    private void Awake()
    {
        instance = this;
    }

    public void AddAnimal()
    {
        animales++;

        Debug.Log("Animales rescatados: " + animales);

        // Cuando tenga 3 animales
        if (animales >= 3)
        {
            puerta.SetActive(false);

            Debug.Log("La puerta se abrió");
        }
    }
}