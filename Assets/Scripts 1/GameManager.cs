using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentPlayerIndex;
    public List<PlayerMove> playerList;

    private void Start()
    {
        PlayerMove[] Players = FindObjectsOfType<PlayerMove>();
        foreach (PlayerMove p in Players)
        {
            playerList.Add(p);
        }
        currentPlayerIndex = 0;
    }
    //For each dice roll after the steps for the player is <= 0
    //then their turn has been done, after the prompt and when they decide to 
    //do whatever with the property they have landed on, it would be time to shift turns
    public void ChangeTurn(int index)
    {
        PlayerMove currentPlayer = playerList[currentPlayerIndex];
        if (currentPlayer.steps <= 0 && !currentPlayer.isMoving)
        {
            if (currentPlayerIndex <= 3)
                currentPlayerIndex++;
            else
                currentPlayerIndex = 0;
            currentPlayer.isTurn = false;

            playerList[currentPlayerIndex].isTurn = true;
        }
        Debug.Log($"It's player {currentPlayerIndex}'s turn");
    }
}
