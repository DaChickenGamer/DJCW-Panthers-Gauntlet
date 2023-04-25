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

    [SerializeField] private Interacter interacter;
    private bool _doorIsActive = false;


    [HideInInspector]
    [Header("Coach Bool")]
    public Dialogue dialogue;


    public bool Interact(Interacter interactor)
    {
        Debug.Log("Opening Door!");
        _doorIsActive = true;
        bool MetCoach = Dialogue.metCoach;
        if (MetCoach == true && enterDoor == true)
        {
            if (_doorIsActive == false)
            {
                Debug.Log("Door Popup Closed");
                awayFromDoor.Invoke();
            }
            if (_doorIsActive == true)
            {
                Debug.Log("Door Popup Menu");
                customEvent.Invoke();
            }
        }
        else if (MetCoach == false && enterDoor == true)
        {
            if (_doorIsActive == false)
            {
                Debug.Log("Door Popup Closed!!");
                awayFromDoor.Invoke();
            }
            else if (_doorIsActive == true)
            {
                Debug.Log("Haven't met coach yet");
                talkToCoach.Invoke();
            }
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Entered Door");
        enterDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Left Door");
        enterDoor = false;
        _doorIsActive = false;
        awayFromDoor.Invoke();
    }
}
