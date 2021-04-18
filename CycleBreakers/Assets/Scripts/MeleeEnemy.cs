using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
    
{

    [SerializeField] private int damageAmount;

    // Start is called before the first frame update
    new void Awake()
    {
        base.Awake();
    }

    public override void getAttack()
    {
        GetComponent<Player>().takeDamage(damageAmount);
    }

    public override void getMovement()
    {
        move = AIMovement.getMovement(target.transform, speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit Player");
            getAttack();
        }  
    }
}
