using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    private List<Enemy> allEnemies = new List<Enemy>();

    [SerializeField] private int enemyWaveCount = 0;
    [SerializeField] private Enemy MeleePrefab = null;
    [SerializeField] private Enemy RangedPrefab = null;
    [SerializeField] private Enemy Boss = null;

    [SerializeField] public float spawnCooldown = 0;
    private float spawnTime = 0;
    private EnemyFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        factory = new EnemyFactory(RangedPrefab, MeleePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
    }

    public void spawnWave()
    {
        //this will change to work with our trigger instead of spawn timer
        if(spawnTime <= 0)
        {
            Enemy e;
            for(int i =0; i < enemyWaveCount; i++)
            {
                e = (Enemy)factory.produce();
                allEnemies.Add(e);
                e.killEnemy += removeEnemy;
                e.setTarget(GameManager.instance().getPlayer());
            }
            spawnTime = spawnCooldown;
        }
        
    }

    public List<Enemy> getEnemies()
    {
        return allEnemies;
    }

    public void removeEnemy(Enemy e)
    {
        allEnemies.Remove(e);
    }
}
