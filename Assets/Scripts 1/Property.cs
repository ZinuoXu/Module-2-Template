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
        Players[playIndex].GetComponent<Player>().currentMoney -= Rent;
        Players[ownerIndex].GetComponent<Player>().currentMoney += Rent;
    }
    //after checking the status of ownership on properteis, This function will help the player to buy it.
    public void Buy(int playIndex)
    {
        Players[playIndex].GetComponent<Player>().currentMoney -= price;
        ownerIndex = Players[playIndex].GetComponent<Player>().playerIndex;
        isBought = true;
        Players[playIndex].GetComponent<Player>().ownedProperty.Add(this);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (Players[manager.currentPlayerIndex].GetComponent<Player>().isMoving == false)
        { 
            int index = other.GetComponent<Player>().playerIndex;
            Debug.Log($"Player {index} is on the property");
            if (other.tag == "Player")
            {
                Debug.Log($"Name: {name}, Description: {Description}");
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
    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
    //public void SetBuyPrompt()
    //{
    //    this.PropertyDesc.text = this.Description;
    //    buyPrompt.SetActive(true);
    //    BuyBt.onClick.AddListener(() => Buy(1));
    //}
    //public void SetRentPrompt()
    //{
    //    this.RentDesc.text = $"Rent for the property is ${this.Rent}";
    //    RentPrompt.SetActive(true);
    //    BuyBt.onClick.AddListener(() => GetRent(1 ,this.Rent));
    //}   

}

