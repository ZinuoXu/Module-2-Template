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
    [HideInInspector] public List<Player> Players = new List<Player>();
    public static GameObject buyPrompt, Auctionprompt, RentPrompt;

    private void Awake()
    {
        buyPrompt = GameObject.Find("buyPrompt");
        buyPrompt.SetActive(false);
        Auctionprompt = GameObject.Find("AuctionPrompt");
        Auctionprompt.SetActive(false);
        RentPrompt = GameObject.Find("RentPrompt");
        RentPrompt.SetActive(false);


        Players.Add(FindObjectOfType<Player>());
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].playerIndex = ownerIndex;
        }
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
