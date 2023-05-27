using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int playerIndex;
    public List<Property> ownedProperty = new List<Property>();
    public int initialMoney = 1500, currentMoney;
    public GameRoute currentRoute;
    int routePosition;
    public int steps = 0;
    public bool isMoving;
    public Dice dice1, dice2;
    public bool isTurn = false;

    private void Start()
    {
        currentMoney = initialMoney;
    }

    public void OnRoll()
    {
        steps = dice1.GetDiceValue();
        Debug.Log(steps);
        steps = steps + dice2.GetDiceValue();
        Debug.Log(steps);
        StartCoroutine(Move());
    }

    private void Update()
    {
        if (dice1.hasLanded && dice2.hasLanded && !isMoving)
        {
            StartCoroutine(Move());
        }
    }

    public IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        while (steps > 0)
        {
            routePosition++;
            routePosition %= currentRoute.childrenNodeList.Count;
            Vector3 nextPos = currentRoute.childrenNodeList[routePosition].position;
            while (MoveToNextNode(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.2f);
            steps--;
            //routePosition++;
        }

        isMoving = false;
    }


    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
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
