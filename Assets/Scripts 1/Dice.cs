using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] public bool hasLanded, thrown;
    public Player currentPL;
    GameManager manager;

    Vector3 initPosition;

    int diceValue;
    public DiceSide[] diceSides = new DiceSide[6];

    public int GetDiceValue()
    {
        return diceValue;
    }



    private void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        currentPL = manager.playerList[manager.currentPlayerIndex].GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    public void OnClick()
    {
        RollDice();
    }
    private void Update()
    {
        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            DiceValueCheck();

        }
        else if (rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            RollAgain();
        }
    }

    void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }
        else if (thrown && hasLanded)
        {
            Reset();
        }
    }

    private void Reset()
    {
        transform.position = initPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }
    private void RollAgain()
    {

        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));


    }

    void DiceValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue + " has been rolled");
                manager.playerList[manager.currentPlayerIndex].GetComponent<Player>().OnRoll();
                Reset();
            }
        }
    }
}