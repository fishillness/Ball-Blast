using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public static CoinCollector Instance;
    [SerializeField] private int coins;
    [SerializeField] private Text text;

    public int Coins => coins;

    private void Start()
    {
        Load();
    }
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
        Save();
    }
    public void SubCoins(int value)
    {
        if (value >= coins)
            coins -= value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("CoinCollector:Coins", coins);
    }
    private void Load()
    {
        coins = PlayerPrefs.GetInt("CoinCollector:Coins", 0);
    }
}
