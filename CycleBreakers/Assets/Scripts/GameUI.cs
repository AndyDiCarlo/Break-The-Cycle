using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{

    public Player player;
    public List<Image> health;  

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(player.health);
    }

    // Update is called once per frame
    public void UpdateHealth(int health)
    {
        if(health <= 0){
            return;
        }
        if(health >= 12){
            health = 12;
        }
        for(int i = 11; i >0; i--){
            Debug.Log(health + " Here1");
            Debug.Log(this.health[1].enabled);
            if(health-1 >= i){
                this.health[i].enabled = true;
            }
            else
            {
                this.health[i].enabled = false;
            }
        }
    }
}
