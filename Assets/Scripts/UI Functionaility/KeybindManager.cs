using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeybindManager : MonoBehaviour
{

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation=null;
    private static KeybindManager instance;
    [SerializeField] private GameObject MovementKeybinds;
    [SerializeField] private GameObject ActionKeybinds;
    [SerializeField] private GameObject ButtonMapping;
    public InputActionMap Actions;
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
    void Start()
    {
        
        Keybinds = new Dictionary<string, KeyCode>();

        ActionBinds = new Dictionary<string, KeyCode>();
        if (SystemInfo.deviceType == DeviceType.Desktop) 
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
        if (SystemInfo.deviceType == DeviceType.Console)
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
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            MovementKeybinds.SetActive(false);
            ActionKeybinds.SetActive(false);
            ButtonMapping.SetActive(true);

        }
    }

    public void BindKey(string key, KeyCode keyBind)
    {
        Dictionary<string, KeyCode> currentDictionary = Keybinds;

        if (key.Contains("ACT"))
        {
            currentDictionary = ActionBinds;
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

        currentDictionary[key] = keyBind;
        KeybindMenu.MyInstance.UpdateKeyText(key, keyBind);
        bindName = string.Empty;
        if (SystemInfo.deviceType == DeviceType.Desktop) 
        {
            if (key == "UP") Actions.FindAction("Movement").ChangeBinding(1).WithPath("<Keyboard>/" + keyBind.ToString());
            if (key == "LEFT") Actions.FindAction("Movement").ChangeBinding(2).WithPath(" < Keyboard>/" + keyBind.ToString());
            if (key == "DOWN") Actions.FindAction("Movement").ChangeBinding(3).WithPath("<Keyboard>/" + keyBind.ToString());
            if (key == "RIGHT") Actions.FindAction("Movement").ChangeBinding(4).WithPath("<Keyboard>/" + keyBind.ToString());
            if (key == "ACTPUNCH") Actions.FindAction("Punch").ChangeBinding(0).WithPath("<Keyboard>/" + keyBind.ToString());
            if (key == "ACTKICK") Actions.FindAction("Kick").ChangeBinding(0).WithPath("<Keyboard>/" + keyBind.ToString());
            if (key == "ACTGRAPPLE") Actions.FindAction("Grapple").ChangeBinding(0).WithPath("<Keyboard>/" + keyBind.ToString());
            if (key == "ACTINTERACT") Actions.FindAction("Interact").ChangeBinding(0).WithPath("<Keyboard>/" + keyBind.ToString());
            if (key == "ACTPAUSE") Actions.FindAction("Pause").ChangeBinding(0).WithPath("<Keyboard>/" + keyBind.ToString()); 
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
