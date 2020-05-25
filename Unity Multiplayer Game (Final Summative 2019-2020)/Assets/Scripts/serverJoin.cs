using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class serverJoin : MonoBehaviour
{
    public GameObject networkManagerObject;
    public NetworkManager manager;

    public GameObject inputField;

    public GameObject clientInputField;

    void Awake(){
        networkManagerObject = GameObject.Find("NetworkManager");
        manager = networkManagerObject.GetComponent<NetworkManager>();
        }


    public void HostIP(){
         if (inputField.GetComponent<Text>().text == null){manager.networkAddress = "localhost";return;}
         manager.networkAddress = inputField.GetComponent<Text>().text;
    }
    public void ClientIP(){
         if (clientInputField.GetComponent<Text>().text == null){manager.networkAddress = "localhost";return;}
         manager.networkAddress = clientInputField.GetComponent<Text>().text;
    }
    public void StartHost(){
        manager.StartHost();
        gameObject.SetActive(false);
    }
    public void StartClient(){
           manager.StartClient();
           gameObject.SetActive(false);
    }
}

