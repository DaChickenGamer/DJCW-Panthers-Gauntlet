using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    [Header("Door Popup")]
    [SerializeField] private UnityEvent customEvent;
    [SerializeField] private UnityEvent talkToCoach;
    [SerializeField] private UnityEvent awayFromDoor;
    [HideInInspector] public bool enterDoor = false;

    [HideInInspector]
    [Header("Coach Bool")]
    public Dialogue dialogue;
    private bool inDoor;


    public bool Interact(Interacter interactor)
    {
        Debug.Log("Opening Door!");
        bool MetCoach = Dialogue.metCoach;
        if (MetCoach == true && inDoor == false)
        {
            Debug.Log("Door Popup Menu");
            inDoor = true;
            customEvent.Invoke();
        }
        else if (MetCoach == false && inDoor == false)
        {
            Debug.Log("Haven't met coach yet");
            inDoor = true;
            talkToCoach.Invoke();
        }
        else if (inDoor == true)
        {
            inDoor = false;
            awayFromDoor.Invoke();
        }
        return true;
    }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("test");
            if (collider.gameObject.name == "ExitDoor")
            {
                Debug.Log("Enter Door");
                enterDoor = true;
            }
        }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("test");
        if (collider.gameObject.name == "ExitDoor")
        {
            awayFromDoor.Invoke();
            Debug.Log("Exit Door");
            enterDoor = false;
        }
    }
}
