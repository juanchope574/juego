using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;

    [Header("Cantidad de llaves")]
    public int keys = 0;

    [Header("Objetos que bloquean")]
    public GameObject ramas;
    public GameObject objeto2;

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
            // Desaparecen los objetos
            ramas.SetActive(false);
            objeto2.SetActive(false);

            Debug.Log("Los objetos desaparecieron");
        }
    }
}