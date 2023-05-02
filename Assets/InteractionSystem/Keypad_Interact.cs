using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad_Interact : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    [SerializeField] private GameObject keypadCanvas;
    public void Awake()
    {
        keypadCanvas.gameObject.SetActive(false);
    }
    public bool Interact(Interacter ineracter)
    {
        Debug.Log("Interacting With Keypad");
        Debug.Log("KeyPad Canvas: " + keypadCanvas.gameObject.activeSelf);
        if(keypadCanvas.gameObject.activeSelf == true)
        {
            keypadCanvas.gameObject.SetActive(false);
        }
        else if (keypadCanvas.gameObject.activeSelf == false)
        {
            keypadCanvas.gameObject.SetActive(true);
        }
        return true;
    }

}
 