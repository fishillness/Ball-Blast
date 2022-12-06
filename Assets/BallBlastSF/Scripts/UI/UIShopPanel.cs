using UnityEngine;
using UnityEngine.UI;

public class UIShopPanel : MonoBehaviour
{
    [SerializeField] private Turret turret;

    [SerializeField] private Text textCostRateOfFire;
    [SerializeField] private Text textCostDamage;
    [SerializeField] private Text textCostProjectileAmount;

    [SerializeField] private int costRateOfFire;
    [SerializeField] private int costDamage;
    [SerializeField] private int costProjectileAmount;

    [SerializeField] private float stepRateOfFire;
    [SerializeField] private int stepDamage;
    [SerializeField] private int stepProjectileAmount;

    [SerializeField] private Button buttonRateOfFire;
    [SerializeField] private Button buttonDamage;
    [SerializeField] private Button buttonProjectileAmount;

    private void Start()
    {
        textCostRateOfFire.text = costRateOfFire.ToString();
        textCostDamage.text = costDamage.ToString();
        textCostProjectileAmount.text = costProjectileAmount.ToString();

        buttonRateOfFire.interactable = false;
        buttonDamage.interactable = false;
        buttonProjectileAmount.interactable = false;
    }

    private void Update()
    {
        if (CoinCollector.Instance.Coins >= costRateOfFire)
            buttonRateOfFire.interactable = true;
        else
            buttonRateOfFire.interactable = false;

        if (CoinCollector.Instance.Coins >= costDamage)
            buttonDamage.interactable = true;
        else
            buttonDamage.interactable = false;

        if (CoinCollector.Instance.Coins >= costProjectileAmount)
            buttonProjectileAmount.interactable = true;
        else
            buttonProjectileAmount.interactable = false;
    }

    public void ButtonRateOfFirePressed()
    {
        turret.ImprovefireRate(stepRateOfFire);
        CoinCollector.Instance.SubCoins(costRateOfFire);
    }
    public void ButtonDamagePressed()
    {
        turret.ImproveDamage(stepDamage);
        CoinCollector.Instance.SubCoins(costDamage);
    }
    public void ButtonProjectileAmountPressed()
    {
        turret.ImproveProjectileAmount(stepProjectileAmount);
        CoinCollector.Instance.SubCoins(costDamage);
    }
}
