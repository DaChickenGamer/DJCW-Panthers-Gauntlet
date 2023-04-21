using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keybind : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI buttonUp;
    [SerializeField] private TextMeshProUGUI buttonLeft, buttonDown, buttonRight, buttonPunch, buttonKick, buttonGrapple, buttonInteract, buttonPause;

    // Start is called before the first frame update
    void Start()
    {
        buttonUp.text = PlayerPrefs.GetString("CustomKeyUp");
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonUp.text == "Awaiting Input")
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    buttonUp.fontSize = 30;
                    buttonUp.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("UP", keycode);
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
                    buttonLeft.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("LEFT", keycode);
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
                    buttonDown.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("DOWN", keycode);
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
                    buttonRight.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("RIGHT", keycode);
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
                    buttonPunch.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("ACTPUNCH", keycode);
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
                    buttonKick.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("ACTKICK", keycode);
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
                    buttonGrapple.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("ACTGRAPPLE", keycode);
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
                    buttonInteract.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("ACTINTERACT", keycode);
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
                    buttonPause.text = keycode.ToString();
                    KeybindMenu.MyInstance.UpdateKeyText("ACTPAUSE", keycode);
                    PlayerPrefs.SetString("CustomKeyPause", keycode.ToString());
                    PlayerPrefs.Save();
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
