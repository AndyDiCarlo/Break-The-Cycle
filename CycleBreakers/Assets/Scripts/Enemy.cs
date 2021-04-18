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

    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;
    [SerializeField] private int attackSpeed;
    [SerializeField] private float maxSpeed;
    protected float speed;
    private float cooldown;

    public System.Action<Enemy> killEnemy;

    // Start is called before the first frame update
    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        AIMovement = GetComponent<IAIMove>();
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

    public virtual void takeDamage(int damageDone)
    {
        health -= damageDone;
        if(health <= 0)
        {
            death();
        }
    }
      
}
