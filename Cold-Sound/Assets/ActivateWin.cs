using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWin : MonoBehaviour
{
    EndGameCanvasHandler endGame;
    private void Start()
    {
        endGame = FindObjectOfType<EndGameCanvasHandler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            endGame.Win();
            Player_Movement_Law.isAlive = false;
        }
    }
}
