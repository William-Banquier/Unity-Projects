using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infectedCount : MonoBehaviour
{
    public Text iCount;
    public Text gameOver;

    public bool gameStarted = false;

    public bool noMorePlayers = false;

    void Update()
    {
        iCount.text = "Infected: "+(GameObject.FindGameObjectsWithTag("I").Length);

        if(GameObject.FindGameObjectsWithTag("Player").Length == 0){
            noMorePlayers = true;
            //Debug.Log("No more players");
        }else{
            noMorePlayers = false;
        }

        if (noMorePlayers == true){
            gameOver.text = "Gameover: True";
        }else{
            gameOver.text= "Gameover: False";
        }
        
    }   
}
