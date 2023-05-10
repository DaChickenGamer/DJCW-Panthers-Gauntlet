using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugController : MonoBehaviour
{
    [SerializeField] private Keypad keypad;
    [SerializeField] private EnemyController enemyController;
    private GameObject _player;
    private GameObject _keypad;
    [SerializeField] private bool _showConsole;
    private GameObject _playerHealth;
    private bool _onReturnActive;
    private bool _testingTools;
    string input;

    public static DebugCommand HEALTH; // Increases Health by 100
    public static DebugCommand TESTINGLEVEL; // Teleports to gym
    public static DebugCommand TALKCOACH; // Makes it so you already talked to the coach
    public static DebugCommand TESTTOOLS; // Enables Testing Tools like Damage
    // Add Increased Damage, God Mode, and Enabling Keys To QUickly Kill Yourself or The Enemy
    public List<object> commandList;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");

        //_onReturnActive = _playerHealth.onReturnActive;

        HEALTH = new DebugCommand("health", "Gives the player health.", "health", () =>
        {
            _player.GetComponent<PlayerHealth>().IncreaseHealth();
            UnityEngine.Debug.Log("Increased Health");
        });
        TESTINGLEVEL = new DebugCommand("testinglevel", "Teleports player to gym.", "testinglevel", () =>
        {
            SceneManager.LoadSceneAsync(2 );
            UnityEngine.Debug.Log("Changed to gym.");
        });
        // ADD
        /*TALKCOACH = new DebugCommand("talkcoach", "Enables Talk To Coach", "talkcoach", () =>
        {
            playerHealth.IncreaseHealth();
            UnityEngine.Debug.Log("Coach Bool Enabled");
        });*/
        TESTTOOLS = new DebugCommand("testtools", "Enables Damage Keybind", "testtools", () =>
        {
            enemyController.DevTools();
            UnityEngine.Debug.Log("Dev Tools Enabled");
        });
        commandList = new List<object>()
        {
            HEALTH,
            TESTINGLEVEL,
            TALKCOACH,
            TESTTOOLS
        };
    }
    private void Update()
    {
        //_onReturnActive = _player.GetComponent<PlayerHealth>().onReturnActive;
        _testingTools = enemyController.testingTools;
        //if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gym"))
        //    _showConsole = keypad.showConsole;
        if (_onReturnActive) // Fix Late - You have to press twice to fix input
        {
            if (_showConsole)
            {
                HandleInput();
                input = "";
            }
        }
    }
    private void OnGUI()
    {
        if (!_showConsole) { return; }

        float y = 0f;

        GUI.Box(new Rect(0.0f, y, Screen.width, 100.0f), "");
        GUI.backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        //GUI.skin.textField.fontSize = fontSize; //ADD THIS LINE and add a variable or hard code a size.
        input = GUI.TextField(new Rect(10.0f, y + 5.0f, Screen.width - 20.0f, 100.0f), input);
    }
    private void HandleInput()
    {
        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (input.Contains(commandBase.commandId))
            {
                if (commandList[i] as DebugCommand != null)
                {
                    // Cast to this type and invoke the command
                    (commandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
}
