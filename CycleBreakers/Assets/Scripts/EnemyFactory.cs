using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IFactory
{

    private Enemy rangedEnemy;
    private Enemy meleeEnemy;
    public int currentRoom;

    public EnemyFactory(Enemy ranged, Enemy melee)
    {
        this.rangedEnemy = ranged;
        this.meleeEnemy = melee;
        currentRoom = 0;
    }

    public IProduct produce()
    {
        float meleeChance = 0.5f;
        float x=-8f, y=3.1f;

        currentRoom = GameObject.Find("Player").GetComponent<Player>().roomNumber;

        //where to spawn (room 1-4 in order)
        if (currentRoom == 0)
        {
            x = Random.Range(-8.2f, -7.75f);
            y = Random.Range(3f, 3.9f);
        }
        if(currentRoom == 1)
        {
            x = Random.Range(-8.2f, -7.3f);
            y = Random.Range(.75f, 1f);
        }
        if (currentRoom == 2)
        {
            x = Random.Range(-3.9f, -3.6f);
            y = Random.Range(.75f, 1.6f);
        }
        if (currentRoom == 3)
        {
            x = Random.Range(-4.6f, -3.6f);
            y = Random.Range(3.65f, 3.9f);
        }

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

    public void setCurrentRoom(int roomNum)
    {
        currentRoom = roomNum;
    }
    
}
