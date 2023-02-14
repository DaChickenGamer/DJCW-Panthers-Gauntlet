using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grapple : MonoBehaviour
{
    [SerializeField] private int grappleWinCounter = 0;
    [SerializeField] private bool inGrappleState = false;


    // Higher for harder characters
    [SerializeField] private float delay = 1f;

    // Make wincount higher for harder characters
    [SerializeField] private int winCount = 10;

    // Makes the fight easier by giving the player a bigger saftey net
    [SerializeField] private int failCount = -10;

    private bool inputDelay = false;
    
    private void OnGrapple(InputValue value)
    {
        if (inGrappleState == false)
        {
            grappleWinCounter = 0;
            inGrappleState = true;
        }
        else if (inGrappleState == true)
        {
                Debug.Log("Grapple " + grappleWinCounter);
                grappleWinCounter++;
        }

            Debug.Log("GrappleState " + inGrappleState);
    }
    void Update() 
    {
        if (inGrappleState == true)
        {
            if (grappleWinCounter >= winCount)     //detects player's success in grapple
            {
                Debug.Log("You won the grapple");
                grappleWinCounter = 0;
                inGrappleState = false;
            }

            if (grappleWinCounter <= failCount)    //detects player's falure in grapple
            {
                Debug.Log("You lossed the grapple");
                grappleWinCounter = 0;
                inGrappleState = false;
            }

            if (inputDelay == false) //delays bot input
            {
                StartCoroutine(BotDelay());
                inputDelay = true;
            }
            
        }

        

    }

    IEnumerator BotDelay()      //delays value addition
    {
        yield return new WaitForSeconds(delay);

        grappleWinCounter --;
        Debug.Log("Grapple " + grappleWinCounter);
        inputDelay = false;
    }
}
