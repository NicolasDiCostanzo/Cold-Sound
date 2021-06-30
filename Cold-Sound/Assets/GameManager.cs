using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int nbKeys = 0;
    AN_DoorScript doorScript;
    
    void Start()
    {
        doorScript = GameObject.Find("Door").GetComponent<AN_DoorScript>();
    }

    void FixedUpdate()
    {
        Debug.Log(nbKeys);
        if(nbKeys == 3)
        {
            doorScript.isOpened = true;
        }
    }

    public static void Lose()
    {
        Debug.Log(":'(");
    }
}
