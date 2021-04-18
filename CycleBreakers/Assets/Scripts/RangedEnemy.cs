using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private float timeToAttack = 0f;
    private float attackTime = 0f;

    new void Awake()
    {
        if (projectile == null)
        {
            Debug.LogError("No Projectile");
        }
        base.Awake();
    }

    public override void getAttack()
    {
        if(attackTime <= 0)
        {

        }
        attackTime -= Time.deltaTime;
    }
    public override void getMovement()
    {
        move = AIMovement.getMovement(target.transform, speed);
    }

}
