using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : MonoBehaviour
{
    public static UILevelProgress Instance;

    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private StoneSpawner stoneSpawner;
    [SerializeField] private Stone stone;

    [SerializeField] private Text currentLeveLText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image progressBar;

    public int amountStoneDestroed;
    private float fillAmountStep;

    private void Start()
    {
        currentLeveLText.text = levelProgress.CurrentLevel.ToString();
        nextLevelText.text = (levelProgress.CurrentLevel + 1).ToString();
        progressBar.fillAmount = 0;

        amountStoneDestroed = 0;

        fillAmountStep = 1f / (stoneSpawner.Amount * 16f);
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        progressBar.fillAmount = amountStoneDestroed * fillAmountStep;
    }
}
