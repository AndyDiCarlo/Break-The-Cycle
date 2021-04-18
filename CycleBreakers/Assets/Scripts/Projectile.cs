using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed =0f;
    public int damage = 0;
    private Rigidbody2D rb;
    private Vector2 moveAmount;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + moveAmount * Time.deltaTime);
    }

    public void setTarget(Transform target){
        moveAmount = target.position - this.transform.position;
        moveAmount = moveAmount.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            other.GetComponent<Player>().takeDamage(damage);
        }
        
    }
}
