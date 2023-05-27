using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentPlayerIndex;
    public GameObject[] playerList;

    private void Awake()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        currentPlayerIndex = 0;
    }
    //For each dice roll after the steps for the player is <= 0
    //then their turn has been done, after the prompt and when they decide to 
    //do whatever with the property they have landed on, it would be time to shift turns
    public void ChangeTurn(int index)
    {
        Player currentPlayer = playerList[currentPlayerIndex].GetComponent<Player>();
        if (currentPlayer.steps <= 0 && !currentPlayer.isMoving)
        {
            if (currentPlayerIndex <= 3)
                currentPlayerIndex++;
            else
                currentPlayerIndex = 0;
            currentPlayer.isTurn = false;

            playerList[currentPlayerIndex].GetComponent<Player>().isTurn = true;
        }
        Debug.Log($"It's player {currentPlayerIndex}'s turn");
    }
}
