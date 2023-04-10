using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    bool hasLanded, thrown;
    PlayerMoveScript plMove;
    Vector3 initPosition;
    public int DiceValue;
    public DiceSide[] diceSides = new DiceSide[6];

    public int GetDiceValue()
    {
        return DiceValue;
    }


    private void RollDice()
    {
        if(!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0,500), Random.Range(0,500), Random.Range(0,500));
        }
        else if(thrown && hasLanded)
        {
            Reset();
        }
    }
    private void Reset()
    {
        transform.position = initPosition;
        rb.useGravity = false;
        thrown = false;
        hasLanded = false;
        plMove.steps = 0;
    }

    private void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0,500), Random.Range(0,500), Random.Range(0,500));
        
    }
    private void DiceValCheck()
    {
        DiceValue = 0;
        foreach(DiceSide side in diceSides)
        {
            if(side.OnGround())
            {
                DiceValue = side.sideValue;
                Debug.Log(DiceValue + "has been rolled.");
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    private void OnClick()
    {
       
        RollDice();

        if(rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            DiceValCheck();
        }
        else if(rb.IsSleeping() && hasLanded && DiceValue == 0)
        {
            RollAgain();
        }
    }
}
