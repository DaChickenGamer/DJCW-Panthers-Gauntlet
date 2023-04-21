using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeybindMenu : MonoBehaviour
{
    private static KeybindMenu instance;
    public static KeybindMenu MyInstance 
    { 
        get 
        {
            if (instance == null)
            { 
                instance = FindObjectOfType<KeybindMenu>(); 
            } 
            return instance; 
        } 
    }
    private GameObject[] keybindButtons;
    private void Awake()
    {
        keybindButtons = GameObject.FindGameObjectsWithTag("Keybind");
    }
    public void UpdateKeyText(string key, KeyCode code)
    {
        TextMeshProUGUI tmp = Array.Find(keybindButtons, x => x.name == key).GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = code.ToString();
    }
}
