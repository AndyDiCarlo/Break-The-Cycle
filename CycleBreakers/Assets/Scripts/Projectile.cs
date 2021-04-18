using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 0f;
    [SerializeField] private int damageAmount = 0;

    private Rigidbody2D rb;
    private Vector2 moveAmount;

    void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.deltaTime);
    }

    public void setTarget(Transform target)
    {
        moveAmount = target.position - this.transform.position;
        moveAmount = moveAmount.normalized * projectileSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(this);
            collision.GetComponent<Player>().takeDamage(damageAmount);
        }
    }
}
