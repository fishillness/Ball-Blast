using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    
    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField] private int amount;
    [SerializeField] [Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private float maxHitpointsRate;

    private float timer;
    private float amountSpawner;
    private int stoneMaxHitpoints;
    private int stoneMinHitpoints;

    private void Start()
    {
        int damagePerSecond = (int) ( (turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate) );

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
        }
    }

    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize( (Stone.Size) Random.Range(1, 4) );
        stone.maxHitPoints = Random.Range(stoneMinHitpoints, stoneMaxHitpoints + 1);
        amountSpawner++;
    }
}
