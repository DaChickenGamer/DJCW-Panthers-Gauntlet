using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keybind : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI buttonUp;
    [SerializeField] private TextMeshProUGUI buttonLeft, buttonDown, buttonRight, buttonPunch, buttonKick, buttonGrapple, buttonInteract, buttonPause;


    // Start is called before the first frame update
    void Start()
    {
        KeybindManager.MyInstance.BindKey("UP", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyUp")));
        KeybindManager.MyInstance.BindKey("LEFT", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyLeft")));
        KeybindManager.MyInstance.BindKey("DOWN", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyDown")));
        KeybindManager.MyInstance.BindKey("RIGHT", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyRight")));

        KeybindManager.MyInstance.BindKey("ACTPUNCH", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyPunch")));
        KeybindManager.MyInstance.BindKey("ACTKICK", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyKick")));
        KeybindManager.MyInstance.BindKey("ACTGRAPPLE", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyGrapple")));
        KeybindManager.MyInstance.BindKey("ACTINTERACT", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyInteract")));
        KeybindManager.MyInstance.BindKey("ACTPAUSE", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKeyPause")));
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            if (buttonUp.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonUp.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("UP", keycode);
                        PlayerPrefs.SetString("CustomKeyUp", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
            if (buttonLeft.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonLeft.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("LEFT", keycode);
                        PlayerPrefs.SetString("CustomKeyLeft", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
            if (buttonDown.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonDown.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("DOWN", keycode);
                        PlayerPrefs.SetString("CustomKeyDown", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
            if (buttonRight.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonRight.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("RIGHT", keycode);
                        PlayerPrefs.SetString("CustomKeyRight", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
            if (buttonPunch.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonPunch.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("ACTPUNCH", keycode);
                        PlayerPrefs.SetString("CustomKeyPunch", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
            if (buttonKick.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonKick.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("ACTKICK", keycode);
                        PlayerPrefs.SetString("CustomKeyKick", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
            if (buttonGrapple.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonGrapple.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("ACTGRAPPLE", keycode);
                        PlayerPrefs.SetString("CustomKeyGrapple", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
            if (buttonInteract.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonInteract.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("ACTINTERACT", keycode);
                        PlayerPrefs.SetString("CustomKeyInteract", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
            if (buttonPause.text == "Awaiting Input")
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(keycode))
                    {
                        buttonPause.fontSize = 30;
                        KeybindManager.MyInstance.BindKey("ACTPAUSE", keycode);
                        PlayerPrefs.SetString("CustomKeyPause", keycode.ToString());
                        PlayerPrefs.Save();
                    }
                }
            }
        }
    }
    public void ChangeKeyUp()
    {
        buttonUp.text = "Awaiting Input";
        buttonUp.fontSize= 18;
    }
    public void ChangeKeyLeft()
    {
        buttonLeft.text = "Awaiting Input";
        buttonLeft.fontSize = 18;
    }
    public void ChangeKeyDown()
    {
        buttonDown.text = "Awaiting Input";
        buttonDown.fontSize = 18;
    }
    public void ChangeKeyRight()
    {
        buttonRight.text = "Awaiting Input";
        buttonRight.fontSize = 18;
    }
    public void ChangeKeyPunch()
    {
        buttonPunch.text = "Awaiting Input";
        buttonPunch.fontSize = 18;
    }
    public void ChangeKeyKick()
    {
        buttonKick.text = "Awaiting Input";
        buttonKick.fontSize = 18;
    }
    public void ChangeKeyGrapple()
    {
        buttonGrapple.text = "Awaiting Input";
        buttonGrapple.fontSize = 18;
    }
    public void ChangeKeyInteract()
    {
        buttonInteract.text = "Awaiting Input";
        buttonInteract.fontSize = 18;
    }
    public void ChangeKeyPause()
    {
        buttonPause.text = "Awaiting Input";
        buttonPause.fontSize = 18;
    }
}
