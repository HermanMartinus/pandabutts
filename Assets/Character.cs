using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Hand leftHand;
    public Hand rightHand;
    public float startingStamina = 100;
    public float dkRate = 0.1f;
    public float dkRateSingleHand = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(leftHand.isMoving || rightHand.isMoving) {
            leftHand.dkRate = dkRateSingleHand;
            rightHand.dkRate = dkRateSingleHand;
        } else {
            leftHand.dkRate = dkRate;
            rightHand.dkRate = dkRate;
        }
    }

    public void ChalkUp() {
        leftHand.stamina = startingStamina;
        rightHand.stamina = startingStamina;
    }
}
