using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMoveScript : MonoBehaviour
{
    public GameRoute currentRoute;
    int routePosition;
    public int steps = 0;
    bool isMoving;
    public Dice dice1, dice2;
 
    public void OnRoll()
    {
        steps += dice1.GetDiceValue();
        //
        //
        //steps += dice2.GetDiceValue();
        StartCoroutine(Move());
    }
 
    private void Update()
    {
        if(dice1.hasLanded && dice2.hasLanded && !isMoving)
        {
            Debug.Log("Dice Rolled " + steps);
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
 
        while(steps > 0)
        {
            routePosition++;
            routePosition %= currentRoute.childrenNodeList.Count;
            Vector3 nextPos = currentRoute.childrenNodeList[routePosition + 1].position;
            while(MoveToNextNode(nextPos)) { yield return null; }
 
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
        }
 
        isMoving = false;
    }
 
 
    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
    }
}