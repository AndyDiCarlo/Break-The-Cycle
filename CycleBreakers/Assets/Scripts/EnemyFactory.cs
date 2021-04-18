using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IFactory
{

    private Enemy rangedEnemy;
    private Enemy meleeEnemy;
    private int currentWave;

    public EnemyFactory(Enemy ranged, Enemy melee)
    {
        this.rangedEnemy = ranged;
        this.meleeEnemy = melee;
        currentWave = 0;
    }

    public IProduct produce()
    {
        float meleeChance = 0.5f;
        //where to spawn
        float x = Random.Range(-5f, 5);
        float y = Random.Range(-5f, 5);

        float rand = Random.Range(0f, 1f);

        if (rand <= meleeChance)
        {
            return spawnEnemy(meleeEnemy, x, y);
        }
        else
        {
            return spawnEnemy(rangedEnemy, x, y);
        }
    }

    private IProduct spawnEnemy(Enemy prefab, float x, float y)
    {
        return Object.Instantiate(prefab, new Vector3(x,y,0f), Quaternion.identity);
    }

    
}
