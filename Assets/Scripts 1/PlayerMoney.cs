using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public int playerIndex;
    public List<int> ownedProperty = new List<int>();
    public int Money = 1500;

    public void DeductMoney(int price)
    {
        if (Money >= price)
        {
            Money -= price;
        }
        else
        {
            Debug.Log("insufficiante funds!");
        }

    }
    public void AddMoney(int price)
    {
        Money += price;
    }
}
