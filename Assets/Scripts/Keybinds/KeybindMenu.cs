using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    public void Update()
    {
    }
    private GameObject[] keybindButtons;
    private void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            keybindButtons = GameObject.FindGameObjectsWithTag("Keybind");
        }
    }
    public void UpdateKeyText(string key, KeyCode code)
    {
        string ReplaceText = code.ToString();
        if (code.ToString().Contains("Arrow"))
        {
            ReplaceText =code.ToString().Replace("Arrow", " Arrow");
        }
        if (code.ToString().Contains("Alpha"))
        {
            ReplaceText = code.ToString().Replace("Alpha", "");
        }
        if (code.ToString().Contains("Mouse0"))
        {
            ReplaceText = code.ToString().Replace("Mouse0", "Left Click");
        }
        if (code.ToString().Contains("Mouse1"))
        {
            ReplaceText = code.ToString().Replace("Mouse1", "Right Click");
        }
        if (code.ToString().Contains("Mouse2"))
        {
            ReplaceText = code.ToString().Replace("Mouse2", "Middle Click");
        }
        if (code.ToString().Contains("Return"))
        {
            ReplaceText = code.ToString().Replace("Return", "Enter");
        }
        SpriteManager.MyInstance.ImageBinding(key, ReplaceText); 
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            TextMeshProUGUI tmp = Array.Find(keybindButtons, x => x.name == key).GetComponentInChildren<TextMeshProUGUI>();
            tmp.text = ReplaceText;
        }
    }

}
