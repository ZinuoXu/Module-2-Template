using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int playerIndex;
    public List<Property> ownedProperty = new List<Property>();
    public int initialMoney = 1500, currentMoney;

    private void Start()
    {
        currentMoney = initialMoney;
    }

    public void DeductMoney(int price)
    {
        if (initialMoney >= price)
        {
            initialMoney -= price;
        }
        else
        {
            Debug.Log("insufficiante funds!");
        }

    }
    public void AddMoney(int money)
    {
        currentMoney += money;
    }
    public bool hasEnoughMoney(int amount)
    {
        return currentMoney >= amount;
    }
    public void AddProperty(Property property)
    {
        ownedProperty.Add(property);
    }
    //changing this to swapping or mortgaging the property to the bank
    public void RemoveProperty(Property property)
    {
        ownedProperty.Remove(property);
    }
}
