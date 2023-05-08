using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameRoute currentRoute;
    int routePosition;
    public int steps = 0;
    [HideInInspector] public bool isMoving;
    public Dice dice1, dice2;
    public bool isTurn = false;

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
}
