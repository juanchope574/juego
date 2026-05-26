using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;

    [Header("Cantidad de llaves")]
    public int keys = 0;

    [Header("Objeto que bloquea")]
    public GameObject ramas;

    private void Awake()
    {
        instance = this;
    }

    public void AddKey()
    {
        keys++;

        Debug.Log("Llaves: " + keys);

        // Cuando tenga 3 llaves
        if (keys >= 3)
        {
            ramas.SetActive(false);

            Debug.Log("Las ramas desaparecieron");
        }
    }
}