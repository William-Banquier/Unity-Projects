using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerInfected : MonoBehaviour
{

    public bool infected = false;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "I"){
            this.gameObject.tag = "I";
        }
    }
}
