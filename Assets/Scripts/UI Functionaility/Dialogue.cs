using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    [Header("Dialogue Parts")]
    public TextMeshProUGUI textComponent;
    public GameObject dialogueBox;
    public GameObject DesktopInteract;
    public GameObject ConsoleInteract;
    public GameObject MobileInteract;
    private float InteractDelay, UnInteractDelay;

    [Header("Dialogue Settings")]
    [SerializeField] private string[] lines= new string[100];
    [SerializeField] private float textSpeed;
    [HideInInspector] [Header("Bools")]
    private bool doDialogue = false;
    private bool skip = false;
    private bool tutorialComplete = false;
    private bool inCoachArea = false;
    private int index;
    private bool DesktopBool, ConsoleBool, MobileBool, OtherBool;

    public static bool metCoach = false;

    private void OnInteract(InputValue value)
    {
        if (doDialogue == false && tutorialComplete == false && inCoachArea == true)
        {
                Debug.Log("Key Pressed");
                doDialogue = true;
                StartDialogue();
        }
        if (doDialogue == true && skip == true) // Checks if it can skip the dialogue
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                tutorialComplete = true;
            }
        }
        if (textComponent.text == lines[index]) // Makes it so you can't skip the first line when clicking onto the dialogue
        {
            skip = true;
        }
    }
    private void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
            DesktopBool = true;
        else if (SystemInfo.deviceType == DeviceType.Console)
            ConsoleBool = true;
        else if (SystemInfo.deviceType == DeviceType.Handheld)
            MobileBool = true;
        else if (SystemInfo.deviceType == DeviceType.Unknown)
            OtherBool = true;
        string[] nextLine = {"hello","UwU","Hehe"};
        
        StopDialogue();
        NewLine(nextLine);
    }
    private void Update()
    {
        if (InteractDelay > 0)
        {
            InteractDelay -= Time.deltaTime;
        }
        if (UnInteractDelay > 0)
        {
            UnInteractDelay -= Time.deltaTime;
        }
        if (DesktopBool)
            Desktop();
        if (ConsoleBool)
            Console();
        if (MobileBool)
            Mobile();
        if (OtherBool)
            Other();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Coach")
        {
            inCoachArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coach")
        {
            StopDialogue();
            inCoachArea = false;
        }
    }
    void StartDialogue()
    {
        textComponent.text = string.Empty;
        textSpeed = 0.1f;
        textComponent.gameObject.SetActive(true);
        dialogueBox.gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }
    void StopDialogue()
    {
        doDialogue = false;
        textSpeed = 100000000000000;
        textComponent.gameObject.SetActive(false);
        dialogueBox.gameObject.SetActive(false);
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index ++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            metCoach = true;
            Debug.Log(metCoach);
            StopDialogue();
        }
    }
    void NewLine(string[] newline)
    {
        lines = newline;
    }
    void Desktop()
    {
        if (InteractDelay <= 0)
        {
            UnInteractDelay = 1;
            DesktopInteract.gameObject.SetActive(true);
            InteractDelay = 2;
        }
        if(UnInteractDelay <= 0)
        {
            DesktopInteract.gameObject.SetActive(false);
        }
    }
    void Console()
    {
        if (InteractDelay <= 0)
        {
            UnInteractDelay = 1;
            ConsoleInteract.gameObject.SetActive(true);
            InteractDelay = 2;
        }
        if (UnInteractDelay <= 0)
        {
            DesktopInteract.gameObject.SetActive(false);
        }
    }
    void Mobile()
    {
        if (InteractDelay <= 0)
        {
            UnInteractDelay = 1;
            MobileInteract.gameObject.SetActive(true);
            InteractDelay = 2;
        }
        if (UnInteractDelay <= 0)
        {
            DesktopInteract.gameObject.SetActive(false);
        }
    }
    void Other()
    {

    }
    IEnumerator TypeLine()
    {
        // Type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
