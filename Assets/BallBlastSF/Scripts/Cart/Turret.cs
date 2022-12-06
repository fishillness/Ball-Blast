using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    [SerializeField] private int projectileAmount;
    [SerializeField] private float projectileInterval;

    public int Damage => damage;
    public int ProjectileAmount => projectileAmount;
    public float FireRate => fireRate;

    private float timer;

    private void Start()
    {
        Load();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void SpawnProjectible()
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;

        for (int i = 0; i < projectileAmount; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, new Vector3(startPosX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z), transform.rotation);
            projectile.SetDamage(damage);
        }
    }

    public void Fire()
    {
        if (timer >= fireRate)
        {
            SpawnProjectible();

            timer = 0;
        }
    }

    public void ImproveDamage(int value)
    {
        damage += value;
        Save();
    }

    public void ImprovefireRate(float value)
    {
        fireRate += value;
        Save();
    }

    public void ImproveProjectileAmount(int value)
    {
        projectileAmount += value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Turret:damage", damage);
        PlayerPrefs.SetFloat("Turret:fireRate", fireRate);
        PlayerPrefs.SetInt("Turret:projectileAmount", projectileAmount);
    }
    private void Load()
    {
        damage = PlayerPrefs.GetInt("Turret:damage", 1);
        fireRate = PlayerPrefs.GetFloat("Turret:fireRate", 0.1f);
        projectileAmount = PlayerPrefs.GetInt("Turret:projectileAmount", 1);
    }

}
