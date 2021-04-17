using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    private Rigidbody2D rb;
    private Vector2 move;

    private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int attackSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        cooldown = attackSpeed;
        speed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveAI();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * Time.deltaTime);
    }

    public void moveAI()
    {
        move = (Vector2)player.transform.position - rb.position; //vector from AI to Player
        float distanceToTarget = move.magnitude;
        move = move.normalized * speed;

        if(rb.tag == "Melee")
        {
            if(distanceToTarget < .5f)
            {
                speed = 0;
            }
            else
            {
                speed = maxSpeed;
            }
        }
        
        if(rb.tag == "Ranged")
        {
            if(distanceToTarget < 1.5f)
            {
                speed = 0;
            }
            else
            {
                speed = maxSpeed;
            }
        }
      
    }
}
