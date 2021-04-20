using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BossState
{
   public Patrol(Boss boss): base(boss){
        name = STATE.PATROL;
        stage = EVENT.ENTER;
   }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update(){
        if (boss.getHealth() <= boss.getMaxHealth()/2){
            stage = EVENT.EXIT;
        }
    }

    public override void Exit(){
        nextState = new Chase(boss);
        base.Exit();
    }


      

   
    
}
