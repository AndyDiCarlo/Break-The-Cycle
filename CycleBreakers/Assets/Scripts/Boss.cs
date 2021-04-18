using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour {

    public Transform[] patrolPoints = null;
    public GameObject projectile = null;
    private BossState state;
    private bool newPoint = true;
    private int targetIndex = 0;
    Rigidbody2D rb;
    public GameObject player;
    private Vector2 move;

    private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int attackSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    private float cooldown;
    
    public System.Action<Boss> killBoss;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        cooldown = attackSpeed;
        speed = maxSpeed;
        //patrolPoints = GameObject.FindGameObjectWithTag("Patrol").GetComponentsInChildren<Transform>();
    }

    public void moveAI()
    {
        
        move = (Vector2)player.transform.position - rb.position; //vector from AI to Player
        float distanceToTarget = move.magnitude;
        move = move.normalized * speed;

        if(distanceToTarget < 1.5f)
        {
            speed = 0;
        }
        else
        {
            Debug.Log("I should be moving");
            speed = maxSpeed;
        }
        
      
    }
        
    
    // Update is called once per frame
    void Update()
    {
        moveAI();
        attack();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * Time.deltaTime);
    }

    public void takeDamage(int amt){
        health -= amt;
        if(health<=0){
            death();
        }
    }
    public void death(){
        killBoss?.Invoke(this);
        Destroy(this.gameObject);
    }

    public void attack(){
        if(cooldown< 0){
            GameObject p = Instantiate(projectile,transform.position,Quaternion.identity);
            p.GetComponent<Projectile>().setTarget(player.transform);
            cooldown = attackSpeed;
        }
        cooldown -=Time.deltaTime;
    }
    
}
