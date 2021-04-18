using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject StartupText;
    public static GameManager _instance = null;

    void Awake(){
        StartupText.SetActive(true);
        if(_instance == null){
            _instance = this;
        } else{
            Destroy(this);
        }
    }

    public static GameManager instance(){
        return _instance;
    }



    private GameState state;
    public Player player;


    void Start()
    {
        state = new Play();
    }

    // Update is called once per frame
    void Update()
    {
        state = state.process();
    }

    public void entityAction(){
        player.move();
        player.attack();
    }
}
