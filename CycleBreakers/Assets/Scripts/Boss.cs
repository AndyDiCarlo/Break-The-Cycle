using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : Enemy {

    public Transform[] patrolPoints = null;
    private BossState state;
    private bool newPoint = true;
    private int targetIndex = 0;

    public System.Action<Boss> killBoss;

    new void Awake(){
        base.Awake();
        state = new Patrol(this);
        patrolPoints= GameObject.FindGameObjectWithTag("PatrolPoints").GetComponentsInChildren<Transform>();
    }
    public int getHealth(){
        return health;
    }

    public int getMaxHealth(){
        return maxHealth;
    }
    public float getSpeed(){
        return speed;
    }
    public void setSpeed(float inc){
        speed=inc;
    }        
    
    // Update is called once per frame
    void Update()
    {
        state = state.process();
    }

    public void getChaseMovement(){
        base.move = AIMovement.getMovement(target.transform,speed);
    }

    public void getPatrolMovement(){
        if (newPoint){
            targetIndex = Random.Range(1,patrolPoints.Length);
            newPoint=false;
        }
        Transform t = patrolPoints[targetIndex];
        base.move = AIMovement.getMovement(t,speed);

        if(base.move == Vector2.zero){
            this.newPoint=true;

        }
    }

    public override void getMovement()
    {
        if (target==null){
            base.getMovement();
            return;
        }
        if(state.GetType()==typeof(Patrol)){
            getChaseMovement();
        }
        if(state.GetType()== typeof(Chase)){
            getChaseMovement();
        }
    }
    public override void takeDamage(int damageDone)
    {
        base.takeDamage(damageDone);
    }



    
}
