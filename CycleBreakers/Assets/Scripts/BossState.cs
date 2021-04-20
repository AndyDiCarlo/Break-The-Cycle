using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState
{
    public enum STATE{
       CHASE, PATROL
   }
    public enum EVENT{
        EXIT, UPDATE, ENTER
    }
    
    protected Boss boss;
    public STATE name;
    protected EVENT stage;
    protected BossState nextState;
    protected GameManager gameManager;


    public virtual void Enter(){
        stage = EVENT.UPDATE;
    }
    public virtual void Update(){
        stage = EVENT.UPDATE;
    }
    public virtual void Exit(){
        stage = EVENT.UPDATE;
    }

    public BossState process(){
        if(stage==EVENT.ENTER) Enter();
        if(stage== EVENT.UPDATE) Update();
        if(stage==EVENT.EXIT){
            Exit();
            return nextState;
        }
        return this;
    }

   public BossState(Boss boss){
       gameManager = GameManager.instance();
       this.boss = boss;
   }

}
