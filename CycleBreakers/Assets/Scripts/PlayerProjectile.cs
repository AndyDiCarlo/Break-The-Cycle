using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 0f;
    [SerializeField] private int damageAmount = 0;

    private Rigidbody2D rb;
    private Vector2 moveAmount;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.deltaTime);
    }

    public void attackDown()
    {
        moveAmount = Vector2.down.normalized * projectileSpeed;
    }

    public void attackUp()
    {
        moveAmount = Vector2.up.normalized * projectileSpeed;
    }

    public void attackLeft()
    {
        moveAmount = Vector2.left.normalized * projectileSpeed;
    }

    public void attackRight()
    {
        moveAmount = Vector2.right.normalized * projectileSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Melee" || collision.tag == "Ranged" || collision.tag =="Boss")
        {
            Destroy(this.gameObject);
            damageAmount = GameObject.Find("Player").GetComponent<Player>().attackDmg;
            collision.GetComponent<Enemy>().takeDamage(damageAmount);
        }
        
        if(collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
