using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ExitDoor : MonoBehaviour
{
    [Header("Door Popup")]
    [SerializeField] private UnityEvent customEvent;
    [SerializeField] private UnityEvent talkToCoach;
    [SerializeField] private UnityEvent awayFromDoor;
    [HideInInspector] public bool enterDoor = false;

    [HideInInspector]
    [Header("Coach Bool")]
    public Dialogue dialogue;
    private void OnInteract(InputValue value)
    {
        bool MetCoach = Dialogue.metCoach;
        if (enterDoor == true && MetCoach == true)
        {
            Debug.Log("Door Popup Menu");
            customEvent.Invoke();
        }
        else if (enterDoor == true && MetCoach == false)
        {
            Debug.Log("Haven't met coach yet");
            talkToCoach.Invoke();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.name == "ExitDoor")
        {
             Debug.Log("Enter Door");
            enterDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.gameObject.name == "ExitDoor")
        {
            awayFromDoor.Invoke();
            Debug.Log("Exit Door");
            enterDoor = false;
        }
    }

}
