using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
     public string level;
    public void start(){
        SceneManager.LoadScene(level);
        Debug.Log("Clicked");
    }
}
