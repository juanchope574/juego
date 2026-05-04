using UnityEngine;
using TMPro;

public class CoinSystem : MonoBehaviour
{
    public static CoinSystem instance;

    public int coins = 0;

    public TextMeshProUGUI coinText;

    void Awake()
    {
        instance = this;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + coins;
    }
}