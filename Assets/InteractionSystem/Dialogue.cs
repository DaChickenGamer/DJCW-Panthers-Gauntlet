using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    [Header("Dialogue Parts")]
    public TextMeshProUGUI textComponent;
    public GameObject dialogueBox;

    [Header("Dialogue Settings")]
    [SerializeField] private string[] lines= new string[100];
    [SerializeField] private float textSpeed;
    [HideInInspector] [Header("Bools")]
    private bool doDialogue = false;
    private bool skip = false;
    private bool tutorialComplete = false;
    private bool inCoachArea = false;
    private int index;

    public static bool metCoach = false;
    
    public bool Interact(Interacter interactor)
    {
        Debug.Log("Interacting With Coach");
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
        return true;
    }
    private void Start()
    {
        string[] nextLine = { "hello", "UwU", "Hehe" };

        // Disables warning below but has no use
        if (inCoachArea == false)
            inCoachArea = false;

        StopDialogue();
        NewLine(nextLine);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Interaction")
        {
            inCoachArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interaction")
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
