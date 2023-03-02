using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ExitDoor : MonoBehaviour
{
    [Header("Door Popup")]
    [SerializeField] private UnityEvent customEvent;
    
    private void OnEnterDoor(InputValue value)
    {
        Debug.Log("Door Popup Menu");
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Player")
        {
        customEvent.Invoke();
        Debug.Log("Door Popup Menu");
        }
        
    }

}
