using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Keybind : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI buttonUp;
    [SerializeField] private TextMeshProUGUI buttonLeft, buttonDown, buttonRight, buttonPunch, buttonKick, buttonGrapple, buttonInteract, buttonPause;
    private bool keyBindDelay=true;
    private float BindingDelay, delaySet=0.1f;

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
        if (keyBindDelay) 
        {
            if (BindingDelay > 0)
            {
                BindingDelay -= Time.deltaTime;
            } 
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            if (!keyBindDelay)
            {
                buttonUp.GetComponentInParent<Button>().interactable = false;
                buttonLeft.GetComponentInParent<Button>().interactable = false;
                buttonDown.GetComponentInParent<Button>().interactable = false;
                buttonRight.GetComponentInParent<Button>().interactable = false;
                buttonPunch.GetComponentInParent<Button>().interactable = false;
                buttonKick.GetComponentInParent<Button>().interactable = false;
                buttonGrapple.GetComponentInParent<Button>().interactable = false;
                buttonInteract.GetComponentInParent<Button>().interactable = false;
                buttonPause.GetComponentInParent<Button>().interactable = false;
            }
            if (BindingDelay <= 0)
            {
                buttonUp.GetComponentInParent<Button>().interactable = true;
                buttonLeft.GetComponentInParent<Button>().interactable = true;
                buttonDown.GetComponentInParent<Button>().interactable = true;
                buttonRight.GetComponentInParent<Button>().interactable = true;
                buttonPunch.GetComponentInParent<Button>().interactable = true;
                buttonKick.GetComponentInParent<Button>().interactable = true;
                buttonGrapple.GetComponentInParent<Button>().interactable = true;
                buttonInteract.GetComponentInParent<Button>().interactable = true;
                buttonPause.GetComponentInParent<Button>().interactable = true;
            }
        }
        /*
        if (KeybindManager.MyInstance.Actions.FindAction("Movement").IsPressed())
        {
            Debug.Log("Movement"+ KeybindManager.MyInstance.Actions.FindAction("Movement").ReadValue<Vector2>());
        }
        if (KeybindManager.MyInstance.Actions.FindAction("Punch").IsPressed())
        {
            Debug.Log("Punch");
        }
        if (KeybindManager.MyInstance.Actions.FindAction("Kick").IsPressed())
        {
            Debug.Log("Kick");
        }
        if (KeybindManager.MyInstance.Actions.FindAction("Grapple").IsPressed())
        {
            Debug.Log("Grapple");
        }
        if (KeybindManager.MyInstance.Actions.FindAction("Interact").IsPressed())
        {
            Debug.Log("Interact");
        }
        if (KeybindManager.MyInstance.Actions.FindAction("Pause").IsPressed())
        {
            Debug.Log("Pause");
        }*/
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
                        keyBindDelay = true;
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
                        keyBindDelay = true;
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
                        keyBindDelay = true;
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
                        keyBindDelay = true;
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
                        keyBindDelay = true;
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
                        keyBindDelay = true;
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
                        keyBindDelay = true;
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
                        keyBindDelay = true;
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
                        keyBindDelay = true;
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
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
    public void ChangeKeyLeft()
    {
        buttonLeft.text = "Awaiting Input";
        buttonLeft.fontSize = 18;
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
    public void ChangeKeyDown()
    {
        buttonDown.text = "Awaiting Input";
        buttonDown.fontSize = 18;
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
    public void ChangeKeyRight()
    {
        buttonRight.text = "Awaiting Input";
        buttonRight.fontSize = 18;
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
    public void ChangeKeyPunch()
    {
        buttonPunch.text = "Awaiting Input";
        buttonPunch.fontSize = 18;
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
    public void ChangeKeyKick()
    {
        buttonKick.text = "Awaiting Input";
        buttonKick.fontSize = 18;
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
    public void ChangeKeyGrapple()
    {
        buttonGrapple.text = "Awaiting Input";
        buttonGrapple.fontSize = 18;
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
    public void ChangeKeyInteract()
    {
        buttonInteract.text = "Awaiting Input";
        buttonInteract.fontSize = 18;
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
    public void ChangeKeyPause()
    {
        buttonPause.text = "Awaiting Input";
        buttonPause.fontSize = 18;
        BindingDelay = delaySet;
        keyBindDelay = false;
        SpriteManager.CanChange = false;
    }
}
