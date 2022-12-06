using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : MonoBehaviour
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private StoneSpawner stoneSpawner;

    [SerializeField] private Text currentLeveLText;
    [SerializeField] private Text nextLevelText;
    [SerializeField] private Image progressBar;

    //private float fillAmountStep;

    private void Start()
    {
        currentLeveLText.text = levelProgress.CurrentLevel.ToString();
        nextLevelText.text = (levelProgress.CurrentLevel + 1).ToString();
        progressBar.fillAmount = 0;

        //fillAmountStep = 1 / stoneSpawner.Amount;
    }
    private void Update()
    {
        //progressBar.fillAmount = stoneSpawner.AmountSpawner / stoneSpawner.Amount;
        progressBar.fillAmount = 1 - FindObjectsOfType<Stone>().Length / 100;
        /* int stoneAmount = FindObjectsOfType<Stone>().Length;
        if (stoneAmount != 0)
        {
            progressBar.fillAmount = 1 - 1 / stoneAmount;
        }
        else
            progressBar.fillAmount = 1; */
    }
}
