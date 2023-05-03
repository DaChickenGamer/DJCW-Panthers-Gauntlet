using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class KeybindManager : MonoBehaviour
{
    private static KeybindManager instance;
    [SerializeField] private GameObject MovementKeybinds;
    [SerializeField] private GameObject ActionKeybinds;
    [SerializeField] private GameObject ButtonMapping;
    public InputActionMap Actions;
    private PlayerInput playerInput;
    string ReplaceText;
    public static KeybindManager MyInstance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<KeybindManager>();
            }
            return instance;
        }
    }

    public Dictionary<string, KeyCode> Keybinds { get; private set; }

    public Dictionary<string, KeyCode> ActionBinds { get; private set; }

    private string bindName;
    // Start is called before the first frame update
    public void Update()
    {
        
    }
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Actions.Enable();
        Keybinds = new Dictionary<string, KeyCode>();

        ActionBinds = new Dictionary<string, KeyCode>();
        if (SystemInfo.deviceType == DeviceType.Desktop) 
        {

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
            {
                MovementKeybinds.SetActive(true);
                ActionKeybinds.SetActive(true);
                ButtonMapping.SetActive(false);

                BindKey("UP", KeyCode.W);
                BindKey("LEFT", KeyCode.A);
                BindKey("DOWN", KeyCode.S);
                BindKey("RIGHT", KeyCode.D);

                BindKey("ACTPUNCH", KeyCode.Z);
                BindKey("ACTKICK", KeyCode.X);
                BindKey("ACTGRAPPLE", KeyCode.C);
                BindKey("ACTINTERACT", KeyCode.E);
                BindKey("ACTPAUSE", KeyCode.Escape);
            }
        }
        if (SystemInfo.deviceType == DeviceType.Console)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
            {
                MovementKeybinds.SetActive(false);
                ActionKeybinds.SetActive(true);
                ButtonMapping.SetActive(false);

                BindKey("ACTPUNCH", KeyCode.A);
                BindKey("ACTKICK", KeyCode.X);
                BindKey("ACTGRAPPLE", KeyCode.Y);
                BindKey("ACTINTERACT", KeyCode.B);
                BindKey("ACTPAUSE", KeyCode.Menu);
            }
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
            {
                MovementKeybinds.SetActive(false);
                ActionKeybinds.SetActive(false);
                ButtonMapping.SetActive(true);
            }

        }
    }

    public void BindKey(string key, KeyCode keyBind)
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            ReplaceText = "<Keyboard>/"+ char.ToLower(keyBind.ToString()[0]) + keyBind.ToString().Substring(1);
            if (keyBind.ToString().Contains("Alpha"))
            {
                ReplaceText = "<Keyboard>/" + keyBind.ToString().Replace("Alpha", "");
            }
            if (keyBind.ToString().Contains("Mouse0"))
            {
                ReplaceText = "<Mouse>/"+ keyBind.ToString().Replace("Mouse0", "leftButton");
            }
            if (keyBind.ToString().Contains("Mouse1"))
            {
                ReplaceText = "<Mouse>/" + keyBind.ToString().Replace("Mouse1", "rightButton");
            }
            if (keyBind.ToString().Contains("Mouse2"))
            {
                ReplaceText = "<Mouse>/" + keyBind.ToString().Replace("Mouse2", "middleButton");
            }
            if (keyBind.ToString().Contains("Return"))
            {
                ReplaceText = "<Keyboard>/" + keyBind.ToString().Replace("Return", "Enter");
            }
            if (keyBind.ToString().Contains("Control"))
            {
                ReplaceText = "<Keyboard>/" + keyBind.ToString().Replace("Control", "Ctrl");
            }
        }
        if (SystemInfo.deviceType == DeviceType.Console)
        {
            ReplaceText = "<XInputController>/"+keyBind.ToString();
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            ReplaceText = null;
        }
        /*Dictionary<string, KeyCode> currentDictionary = Keybinds;

        if (key.Contains("ACT"))
        {
            currentDictionary = ActionBinds;
        }
        if (currentDictionary.ContainsKey(key))
        {
        }
        if (!key.Contains("ACT"))
        {
            currentDictionary = Keybinds;
        }
        if (!currentDictionary.ContainsValue(keyBind))
        {
            currentDictionary.Add(key, keyBind);
            KeybindMenu.MyInstance.UpdateKeyText(key, keyBind);
        }
        else if (currentDictionary.ContainsValue(keyBind))
        {
            string myKey = currentDictionary.FirstOrDefault(x => x.Value == keyBind).Key;

            currentDictionary[myKey] = KeyCode.None;
            KeybindMenu.MyInstance.UpdateKeyText(key, KeyCode.None);
        }

        currentDictionary[key] = keyBind;*/
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            KeybindMenu.MyInstance.UpdateKeyText(key, keyBind);
        }
        bindName = string.Empty;
        if (SystemInfo.deviceType == DeviceType.Desktop) 
        {
            if (key == "UP") Actions.FindAction("Movement").ChangeBinding(1).WithPath(ReplaceText);
            if (key == "LEFT") Actions.FindAction("Movement").ChangeBinding(2).WithPath(ReplaceText);
            if (key == "DOWN") Actions.FindAction("Movement").ChangeBinding(3).WithPath(ReplaceText);
            if (key == "RIGHT") Actions.FindAction("Movement").ChangeBinding(4).WithPath(ReplaceText);
            if (key == "ACTPUNCH") Actions.FindAction("Punch").ChangeBinding(0).WithPath(ReplaceText);
            if (key == "ACTKICK") Actions.FindAction("Kick").ChangeBinding(0).WithPath(ReplaceText);
            if (key == "ACTGRAPPLE") Actions.FindAction("Grapple").ChangeBinding(0).WithPath(ReplaceText);
            if (key == "ACTINTERACT") Actions.FindAction("Interact").ChangeBinding(0).WithPath(ReplaceText);
            if (key == "ACTPAUSE") Actions.FindAction("Pause").ChangeBinding(0).WithPath(ReplaceText); 
        }
        if (SystemInfo.deviceType == DeviceType.Console)
        {
            if (key == "ACTPUNCH") Actions.FindAction("Punch").ChangeBinding(1).WithPath("<XInputController>/" + keyBind.ToString());
            if (key == "ACTKICK") Actions.FindAction("Kick").ChangeBinding(1).WithPath("<XInputController>/" + keyBind.ToString());
            if (key == "ACTGRAPPLE") Actions.FindAction("Grapple").ChangeBinding(1).WithPath("<XInputController>/" + keyBind.ToString());
            if (key == "ACTINTERACT") Actions.FindAction("Interact").ChangeBinding(1).WithPath("<XInputController>/" + keyBind.ToString());
            if (key == "ACTPAUSE") Actions.FindAction("Pause").ChangeBinding(1).WithPath("<XInputController>/" + keyBind.ToString());
        }
    }
}
