using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("Cantidad de monedas")]
    public int coins = 0;

    [Header("Barricada a desbloquear")]
    public GameObject barricada;

    private void Awake()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coins++;

        Debug.Log("Monedas: " + coins);

        // Cuando tenga 3 monedas
        if (coins >= 3)
        {
            barricada.SetActive(false);

            Debug.Log("Barricada desbloqueada");
        }
    }
}