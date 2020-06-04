using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewGame : MonoBehaviour
{
    public bool gameStarted = false;

    void Update()
    {
        if(gameStarted = false){
            if(GameObject.FindGameObjectsWithTag("Player").Length > 1){
                GameObject.FindGameObjectsWithTag("Player")[Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length)].tag = "I";
                
            }
        }
    }
}
