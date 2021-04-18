using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    // Start is called before the first frame update
    new void Awake()
    {
        base.Awake();
    }

    public override void getAttack()
    {
        
    }

    public override void getMovement()
    {
        move = AIMovement.getMovement(target.transform, speed);
    }
}
