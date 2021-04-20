using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IAIMove))]

public abstract class Enemy : MonoBehaviour, IProduct
{

    [SerializeField] protected Player target;
    private Rigidbody2D rb;
    protected Vector2 move;
    protected IAIMove AIMovement;

    [SerializeField] protected int maxHealth = 2;
    [SerializeField] protected int health;
    [SerializeField] private int attackSpeed;
    [SerializeField] private float maxSpeed;
    protected float speed;
    private float cooldown;

    [SerializeField] private GameObject healthPowerUp;
    [SerializeField] private GameObject attackPowerUp;
    [SerializeField] private GameObject cooldownPowerUp;
    [SerializeField] private GameObject speedPowerUp;

    public System.Action<Enemy> killEnemy;

    // Start is called before the first frame update
    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        AIMovement = GetComponent<IAIMove>();
        maxHealth = maxHealth + (1 * GameObject.Find("Player").GetComponent<Player>().loopCount);
        health = maxHealth;
        cooldown = attackSpeed;
        speed = maxSpeed;
    }

    public void setTarget(Player p)
    {
        target = p;
    }


    public virtual void moveEnemy()
    {
        rb.MovePosition(rb.position + move * Time.deltaTime);
    }

    public virtual void getMovement()
    {
        move = Vector2.zero;
    }

    public virtual void getAttack()
    {

    }

    public virtual void death()
    {
        killEnemy?.Invoke(this);
        Destroy(this.gameObject);
    }

    public void spawnPowerUp(Vector2 pos)
    {
        float rand = Random.Range(0f, 1f);

        if(rand >= 0 && rand <= .13f)
        {
            GameObject p = Instantiate(speedPowerUp, pos, Quaternion.identity);
        }
        if(rand > .13f && rand <= .5f)
        {
            GameObject p = Instantiate(healthPowerUp, pos, Quaternion.identity);
        }
        if(rand > .5f && rand <= .75f)
        {
            GameObject p = Instantiate(attackPowerUp, pos, Quaternion.identity);
        }
        if(rand > .75f && rand <= 1f)
        {
            GameObject p = Instantiate(cooldownPowerUp, pos, Quaternion.identity);
        }
    }

    public virtual void takeDamage(int damageDone)
    {
        health -= damageDone;
        int toSpawnPowerUp = GameObject.Find("Manager").GetComponent<SpawnManager>().allEnemies.Count;
        
        if (health <= 0)
        {
            if(this.gameObject.tag != "Boss" && toSpawnPowerUp == 1)
            {
                spawnPowerUp(this.transform.position);
            }
            death();
        }
        
    }
      
}
