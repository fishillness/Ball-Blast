using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private LevelProgress levelProgress;

    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    
    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private float maxHitpointsRate;

    [Space(10)] public UnityEvent Completed;

    private float timer;
    private int amountSpawner;
    private int stoneMaxHitpoints;
    private int stoneMinHitpoints;
    private int amount;
    public int Amount => amount;

    private int damagePerSecond;

    private void Start()
    {
        amount = levelProgress.CurrentLevel;        
        damagePerSecond = (int) ( (turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate) );

        stoneMaxHitpoints = (int)(damagePerSecond * maxHitpointsRate);
        stoneMinHitpoints = (int)(stoneMaxHitpoints * minHitpointsPercentage);
        timer = spawnRate;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            Spawn();
            timer = 0;
        }

        if (amountSpawner == amount)
        {
            enabled = false;
            Completed.Invoke();
        }
    }

    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize(Stone.Size.Huge);
        stone.maxHitPoints = Random.Range(stoneMinHitpoints, stoneMaxHitpoints + 1);
        amountSpawner++;
    }
}
