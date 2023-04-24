using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyManager : MonoBehaviour
{
    public string Name;
    public string Description;
    public int price;
    public bool isBought = false;
    public int index;
    public int ownerIndex;
    //Later we will add a function to get all of the players who are in the game inside this list.
    [HideInInspector] public List<PlayerMoney> Players = new List<PlayerMoney>();
    public static GameObject buyPrompt, Auctionprompt;

    private void Awake()
    {
        //Players = FindObjectsOfType<PlayerMoney>();
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].playerIndex = ownerIndex;
        }
    }


    //after checking the status of ownership on properteis, This function will help the player to buy it.
    public void Buy(int playIndex)
    {
        Players[playIndex].Money -= price;
        ownerIndex = Players[playIndex].playerIndex;
        isBought = true;
        Players[playIndex].ownedProperty.Add(index);



    }
    //This function is for checking the status of the property
    public bool GetStatus()
    {
        return isBought;
    }

    //The player sells the property back to the bank
    public void SellToBank()
    {

    }


}