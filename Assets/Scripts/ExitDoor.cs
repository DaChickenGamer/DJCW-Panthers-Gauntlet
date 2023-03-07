using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ExitDoor : MonoBehaviour
{
    [Header("Door Popup")]
    [SerializeField] private UnityEvent customEvent;
    private bool enterDoor = false;
    private void OnEnterDoor(InputValue value)
    {
        if(enterDoor == true)
        {
            Debug.Log("Door Popup Menu");
            customEvent.Invoke();

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.name == "ExitDoor")
        {
             Debug.Log("Enter Door");
            enterDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.gameObject.name == "ExitDoor")
        {
             Debug.Log("Exit Door");
            enterDoor = false;
        }
    }

}
