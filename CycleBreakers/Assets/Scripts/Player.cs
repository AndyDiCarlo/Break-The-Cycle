using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private int health;

    [SerializeField] private int maxHealth;
    [SerializeField] private float attackSpeed;
    public float cooldown;
    public ParticleSystem attackParticle;
    private bool keyDown;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        cooldown = attackSpeed;
    }


    public void getMovement(){
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = input.normalized * speed;
    }

    public void move(){
        getMovement();
        rb.MovePosition(rb.position+moveAmount*Time.deltaTime);
    }

    public void attack(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            attackParticle.transform.eulerAngles = new Vector3(0,0,-270);
            keyDown = true;
        } else if(Input.GetKey(KeyCode.DownArrow)){
            attackParticle.transform.eulerAngles = new Vector3(0,0,-180);
            keyDown = true;
        } else if(Input.GetKey(KeyCode.RightArrow)){
            attackParticle.transform.eulerAngles = new Vector3(0,0,-90);
            keyDown = true;
        } else if(Input.GetKey(KeyCode.UpArrow)){
            attackParticle.transform.eulerAngles = new Vector3(0,0,-0);
            keyDown = true;
        } else{
            keyDown = false;
        }

        if(keyDown && cooldown >= attackSpeed){
            attackParticle.Play();
            cooldown = 0;
            keyDown = false;
        } else{
            if (cooldown < attackSpeed){
                cooldown += Time.deltaTime;
            }
        }
    }

    public void takeDamage(int amt){
        health -= amt;
        if(health<=0){
            print("Game Over");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
