using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{
    public gamemanager gameManager;
    public GameObject winZone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameManager.ableToWin == true)
        {
            Debug.Log("player has won the game");
        }
    }
}
