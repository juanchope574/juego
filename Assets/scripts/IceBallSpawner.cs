using UnityEngine;

public class IceBallSpawner : MonoBehaviour
{
    public GameObject bolaHieloPrefab;
    public float tiempoEntreBolas = 3f;

    void Start()
    {
        InvokeRepeating("CrearBola", 1f, tiempoEntreBolas);
    }

    void CrearBola()
    {
        Instantiate(bolaHieloPrefab, transform.position, transform.rotation);
    }
}