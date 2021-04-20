using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int healthincrease;
    public int attackincrease;
    public float speedincrease;
    public float cooldownreduce;
    private GameObject obj;
    public GameUI GUI;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        obj = GetComponent<GameObject>();
        
    }

      private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"){
            if(col.tag=="HealthUp"){
                collision.GetComponent<Player>().healthUp(healthincrease);
                GUI.UpdateHealth(collision.GetComponent<Player>().health);
                GameObject.Destroy(gameObject);
            }
            if(col.tag=="AttackUp"){
                collision.GetComponent<Player>().attackUp(attackincrease);
                GameObject.Destroy(gameObject);
            }
            if(col.tag=="SpeedUp"){
                collision.GetComponent<Player>().speedUp(speedincrease);
                GameObject.Destroy(gameObject);
            }
            if(col.tag=="FirerateUp"){
                collision.GetComponent<Player>().firerateUp(cooldownreduce);
                GameObject.Destroy(gameObject);
            }

        }
    }
}
