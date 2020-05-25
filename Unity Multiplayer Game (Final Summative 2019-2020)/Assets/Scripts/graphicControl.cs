using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphicControl : MonoBehaviour
{

    public GameObject fastest;
    public GameObject fast;
    public GameObject simple;
    public GameObject good;
    public GameObject beautiful;
    public GameObject fantastic;


    public int index = 0;

    

    public void SaveData(){
        PlayerPrefs.SetInt("graphicIndex", index);
        PlayerPrefs.Save();
    }
//Use in other scene
    public void LoadData(){
        int graphicIndex = PlayerPrefs.GetInt("graphicIndex");
    }

    public void IncreaseIndex(){
        index+=1;
    }
    public void DeacreaseIndex(){
        index -=1;
    }

    public void unHideFastest(){
        fastest.SetActive(true);
        fast.SetActive(false);
        simple.SetActive(false);
        good.SetActive(false);
        beautiful.SetActive(false);
        fantastic.SetActive(false);
        }
    public void unHideFast(){
        fastest.SetActive(false);
        fast.SetActive(true);
        simple.SetActive(false);
        good.SetActive(false);
        beautiful.SetActive(false);
        fantastic.SetActive(false);
        }
    public void unHideSimple(){
        fastest.SetActive(false);
        fast.SetActive(false);
        simple.SetActive(true);
        good.SetActive(false);
        beautiful.SetActive(false);
        fantastic.SetActive(false);
        }
    public void unHideGood(){
        fastest.SetActive(false);
        fast.SetActive(false);
        simple.SetActive(false);
        good.SetActive(true);
        beautiful.SetActive(false);
        fantastic.SetActive(false); 
        }
    public void unHideBeautiful(){
        fastest.SetActive(false);
        fast.SetActive(false);
        simple.SetActive(false);
        good.SetActive(false);
        beautiful.SetActive(true);
        fantastic.SetActive(false);
         }
    public void unHideFantastic(){
        fastest.SetActive(false);
        fast.SetActive(false);
        simple.SetActive(false);
        good.SetActive(false);
        beautiful.SetActive(false);
        fantastic.SetActive(true);
        }

    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.RightArrow)){IncreaseIndex();}
        if(Input.GetKeyDown(KeyCode.LeftArrow)){DeacreaseIndex();}
        
        if (index == 0){
            unHideFastest();
            QualitySettings.SetQualityLevel(0, true);
            SaveData();
        }
        if (index == 1){
            unHideFast();
            QualitySettings.SetQualityLevel(1, true);
            SaveData();
        }
        if (index == 2){
            unHideSimple();
            QualitySettings.SetQualityLevel(2, true);
            SaveData();
        }
        if (index == 3){
            unHideGood();
            QualitySettings.SetQualityLevel(3, true);
            SaveData();
        }
        if (index == 4){
            unHideBeautiful();
            QualitySettings.SetQualityLevel(4, true);
            SaveData();
        }
        if (index == 5){
            unHideFantastic();
            QualitySettings.SetQualityLevel(5, true);
            SaveData();
        }
        if (index >= 6){
            index = 0;
        }
        if (index <= -1){
            index = 5;
        }
    }
}
