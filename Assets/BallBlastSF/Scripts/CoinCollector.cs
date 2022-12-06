using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public static CoinCollector Instance;
    [SerializeField] private int coins;
    [SerializeField] private Text text;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        text.text = "Coins: " + coins.ToString();
    }
    public void AddCoins(int value)
    {
        coins += value;
    }
}
