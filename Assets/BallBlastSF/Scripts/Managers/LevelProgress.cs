using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private LevelState levelState;

    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    private bool isCheck;

    private void Start()
    {
        isCheck = false;
        levelState.Passed.AddListener(OnPassedLevel);
        Load();
    }
    private void OnDestroy()
    {
        levelState.Passed.RemoveListener(OnPassedLevel);
    }
    private void OnPassedLevel()
    {
        if (isCheck == false)
        {
            currentLevel++;
            isCheck = true;
            Save();
        }
    }
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.F2) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
#endif
    private void Save()
    {
        PlayerPrefs.SetInt("LevelProgress:CurrentLeveL", currentLevel);
    }
    private void Load()
    {
        currentLevel = PlayerPrefs.GetInt("LevelProgress:CurrentLeveL", 1);
    }
    public void ChangeIsCheckOnFalse()
    {
        isCheck = false;
    }
#if UNITY_EDITOR
    private void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
#endif
}
