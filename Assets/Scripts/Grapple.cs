using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private int grappleWinCounter = 0;
    private bool inGrappleState = false;

    private bool inputDelay = false;
    void Update() 
    {
        
        if(Input.GetKeyDown("g"))
        {
            grappleWinCounter = 0;
            inGrappleState = true;
            Debug.Log("GrappleState " + inGrappleState);
        }

        if(inGrappleState == true)
        {
            

            if(Input.GetKeyDown("space"))       //player's grapple input
            {
                Debug.Log("Grapple " + grappleWinCounter);
                grappleWinCounter ++;
            }

            if(grappleWinCounter >= 10)     //detects player's success in grapple
            {
                Debug.Log("You won the grapple");
                grappleWinCounter = 0;
                inGrappleState = false;
            }

            if(grappleWinCounter <= -10)    //detects player's falure in grapple
            {
                Debug.Log("You lossed the grapple");
                grappleWinCounter = 0;
                inGrappleState = false;
            }

            if(inputDelay == false) //delays bot input
            {
                StartCoroutine(BotDelay());
                inputDelay = true;
            }
            
        }

        

    }

    IEnumerator BotDelay()      //delays value addition
    {
        yield return new WaitForSeconds(1f);

        grappleWinCounter --;
        Debug.Log("Grapple " + grappleWinCounter);
        inputDelay = false;
    }
}
