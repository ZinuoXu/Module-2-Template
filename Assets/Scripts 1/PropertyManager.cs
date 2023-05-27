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
    public GameObject[] Players;
    //public static GameObject buyPrompt, Auctionprompt, RentPrompt;
    //public Text PropertyDesc, RentDesc;
    //public Button BuyBt, RentBt, AuctionBt;
    public GameManager manager;

    private void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        //buyPrompt = GameObject.Find("buyPrompt");
        //buyPrompt.SetActive(false);
        //Auctionprompt = GameObject.Find("AuctionPrompt");
        //Auctionprompt.SetActive(false);
        //RentPrompt = GameObject.Find("RentPrompt");
        //RentPrompt.SetActive(false);
        Players = manager.playerList;
        

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
