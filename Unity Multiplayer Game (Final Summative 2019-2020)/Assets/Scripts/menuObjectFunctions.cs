using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuObjectFunctions : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    
    public void closeGame(){
        Application.Quit();
    }

    public void openOption(){
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    public void closeOption(){
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    void Update(){
        if(optionMenu.activeSelf == true){
            if(Input.GetKey(KeyCode.Escape)){
                closeOption();
            }
        }
    }
}
