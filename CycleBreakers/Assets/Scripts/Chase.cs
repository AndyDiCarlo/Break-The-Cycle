using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : BossState
{
   public Chase(Boss boss): base(boss){
       name = STATE.CHASE;
       stage = EVENT.ENTER;
   }

    public override void Enter()
    {
        boss.setSpeed(boss.getSpeed()*2);
        stage = EVENT.UPDATE;
    }
}
