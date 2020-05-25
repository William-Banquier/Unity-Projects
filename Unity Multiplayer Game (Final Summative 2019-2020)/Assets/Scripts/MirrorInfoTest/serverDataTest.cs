using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class serverDataTest : MonoBehaviour
{

    public Text networkAddress;
    public Text isHosting;


    public GameObject networkManagerObject;
    public NetworkManager manager;
    public NetworkManagerHUD managerHUD;

    public bool isHost;

    
    public void exit(){
        if (isHost){
        manager.StopHost();}else{manager.StopClient();}
    }


    void Awake(){
        networkManagerObject = GameObject.Find("NetworkManager");
        manager = networkManagerObject.GetComponent<NetworkManager>();
        managerHUD = networkManagerObject.GetComponent<NetworkManagerHUD>();

        networkAddress.text = "Server: "+manager.networkAddress;
        isHosting.text= "Host: "+(NetworkManagerMode.Host == manager.mode).ToString();

        isHost = (NetworkManagerMode.Host == manager.mode);
    }
}
