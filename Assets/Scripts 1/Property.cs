using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : PropertyManager
{
    public bool isGpBought;
    public int Rent;
    public int numHouses;

    //this function takes rent from the player who has landed on it to the player who owns the property
    public void GetRent(int playIndex, int ownerIndex)
    {
        Players[playIndex].currentMoney -= Rent;
        Players[ownerIndex].currentMoney += Rent;
    }
    //after checking the status of ownership on properteis, This function will help the player to buy it.
    public void Buy(int playIndex)
    {
        Players[playIndex].currentMoney -= price;
        ownerIndex = Players[playIndex].playerIndex;
        isBought = true;
        Players[playIndex].ownedProperty.Add(this);



    }
    public void OnTriggerStay(Collider other)
    {
        int index = other.GetComponent<Player>().playerIndex;
        if (other.tag == "Player")
        {

            if (isBought)
            {
                //Deduct from player index and give to the owner
                GetRent(index, ownerIndex);
                Debug.Log("Pay rent!");
            }
            else
            {
                //Have a prompt to ask the player to buy the property.
                //PropertyManager.buyPrompt.gameObject.SetActive(true);
                Debug.Log("not Bought Yet");
                //Buy(index);
            }
        }
    }
}
