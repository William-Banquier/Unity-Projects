using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infectedCount : MonoBehaviour
{
    public Text iCount;

    void Update()
    {
        iCount.text = "Infected: "+(GameObject.FindGameObjectsWithTag("I").Length);
    }
}
