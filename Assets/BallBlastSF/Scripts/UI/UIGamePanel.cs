using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject passedPanel;
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private GameObject shopPanel;

    private void Start()
    {
        menuPanel.SetActive(true);

        passedPanel.SetActive(false);
        defeatPanel.SetActive(false);
        shopPanel.SetActive(false);
    }

}
