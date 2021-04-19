﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    public int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private float attackSpeed;
    public float cooldown;
    public ParticleSystem attackParticle;
    public int attackDmg;
    private int attackHit;
    private bool keyDown;
    public int loopCount = 0;
    public int roomNumber = 0;
    public GameUI GUI;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        cooldown = attackSpeed;
        attackHit=attackDmg;
        GUI.UpdateHealth(health);
    }


    public void getMovement(){
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = input.normalized * speed;
    }

    public void move(){
        getMovement();
        rb.MovePosition(rb.position+moveAmount*Time.deltaTime);
    }
    public void healthUp(int up){
        maxHealth+=up;
    }
    public void attackUp(int up){
        attackDmg+=up;
    }
    public void speedUp(int up){
        speed+=up;
    }
    public void firerateUp(float down){
       cooldown-=down;
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
        GUI.UpdateHealth(health);
        if(health<=0){
            print("Game Over");
        }
    }

    public void updateRoom(int room)
    {
        //enemyFactory.setCurrentRoom(room);
    }

    void OnTriggerEnter2D(Collider2D other){
        GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");

        if(other.tag=="Door"){
            if(this.transform.position.x < -7.6 && this.transform.position.y > 2.8){
                this.transform.position = new Vector3(this.transform.position.x, 1.7f, this.transform.position.z);
                Cam.transform.position = new Vector3(-7.72f, 1.18f, -1);
                roomNumber = 1;
                GameManager.instance().GetComponent<GameManager>().spawn();
        }
            if(this.transform.position.x < -7.0 && this.transform.position.y < 1.5){
                this.transform.position = new Vector3(-4.64f, this.transform.position.y, this.transform.position.z);
                Cam.transform.position = new Vector3(-4.12f, 1.18f, -1);
                roomNumber = 2;
                GameManager.instance().GetComponent<GameManager>().spawn();
            }
            if(this.transform.position.x < -3.8 && this.transform.position.x > -4.3 && this.transform.position.y > 1.65){
                this.transform.position = new Vector3(this.transform.position.x, 3, this.transform.position.z);
                Cam.transform.position = new Vector3(-4.12f, 3.48f, -1);
                roomNumber = 3;
                GameManager.instance().GetComponent<GameManager>().spawn();
            }
            if(this.transform.position.x < -4.5 && this.transform.position.x > -5 && this.transform.position.y > 2.8){
                loopCount++;
                this.transform.position = new Vector3(-7.2f, 3.48f, this.transform.position.z);
                Cam.transform.position = new Vector3(-7.72f, 3.48f, -1);
                roomNumber = 0;
                GameManager.instance().GetComponent<GameManager>().spawn();
            }
        }

        
    }

    void OnTriggerStay2D(Collider2D other){
        GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject BossCam = GameObject.FindGameObjectWithTag("BossCam");
        if(loopCount>0 && Input.GetKey(KeyCode.Space) && other.tag == "BossTrigger"){
            this.transform.position = new Vector3(-.76f,2.82f,this.transform.position.z);
            Debug.Log("Here");
            BossCam.SetActive(true);
            Cam.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
