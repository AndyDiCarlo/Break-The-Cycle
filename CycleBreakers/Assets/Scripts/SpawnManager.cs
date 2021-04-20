using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager _instance = null;

    public List<Enemy> allEnemies = new List<Enemy>();

    [SerializeField] private int enemyWaveCount = 0;
    [SerializeField] private Enemy MeleePrefab = null;
    [SerializeField] private Enemy RangedPrefab = null;
    [SerializeField] private Enemy Boss = null;

    [SerializeField] public float spawnCooldown = 0;
    private float spawnTime = 0;
    private EnemyFactory factory;

    public static SpawnManager instance()
    {
        return _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        factory = new EnemyFactory(RangedPrefab, MeleePrefab,Boss);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
    }

    public void spawnWave()
    {
        //will spawn wave every time player walks through into new room
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
    public void spawnBoss()
    {
        //will spawn wave every time player walks through into new room
        Enemy e;
        e = (Enemy)factory.produce();
        allEnemies.Add(e);
        e.killEnemy += removeEnemy;
        e.setTarget(GameManager.instance().getPlayer());
        
    }

    public List<Enemy> getEnemies()
    {
        return allEnemies;
    }

    public void removeEnemy(Enemy e)
    {
        allEnemies.Remove(e);
    }

    public bool enemiesClear()
    {
        if(allEnemies.Count != 0)
        {
            return false;
        }
        return true;
    }
}
