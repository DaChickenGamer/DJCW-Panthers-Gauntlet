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
    [SerializeField] private string[] lines = new string[0];
    [SerializeField] private float textSpeed;
    [HideInInspector][Header("Bools")]
    private bool doDialogue = false;
    private bool skip = false;
    private bool tutorialComplete = false;
    private bool inCoachArea = false;
    private bool allowNextLine;
    private int index;


    [HideInInspector][Header("Managers")]
    private SpriteManager sprites;
    private KeybindManager keybinds;

    [HideInInspector][Header("Image Definer")]
    private GameObject upInput;
    private GameObject leftInput, downInput, rightInput, punchInput, kickInput, grappleInput, interactInput, pauseInput;
    private bool upTask, leftTask, downTask, rightTask, punchTask, kickTask, grappleTask, pauseTask;

    public static bool metCoach = false;

    public bool Interact(Interacter interactor)
    {

        if (allowNextLine)
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
        }
        return true;
    }
    private void Awake()
    {
        sprites = SpriteManager.MyInstance;
        upInput = sprites.upimage;
        leftInput = sprites.leftimage;
        downInput = sprites.downimage;
        rightInput = sprites.rightimage;
        punchInput = sprites.punchimage;
        kickInput = sprites.kickimage;
        grappleInput = sprites.grappleimage;
        interactInput = sprites.interactimage;
        pauseInput = sprites.pauseimage;
        keybinds = KeybindManager.MyInstance;
    }
    private void Start()
    {
        upInput.SetActive(true);
        leftInput.SetActive(true);
        downInput.SetActive(true);
        rightInput.SetActive(true);
        punchInput.SetActive(false);
        kickInput.SetActive(false);
        grappleInput.SetActive(false);
        interactInput.SetActive(false);
        pauseInput.SetActive(false);
        string[] nextLine = { "To punch you will need to press", "To kick you will need to press", "To grapple you will need to press", "To pause/unpause you will need to press" };

        // Disables warning below but has no use
        if (inCoachArea == false)
            inCoachArea = false;

        StopDialogue();
        NewLine(nextLine);
    }
    private void Update()
    {
        CoachTutorial();
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
    void CoachTutorial()
    {
        if (keybinds.Actions.FindAction("Movement").ReadValue<Vector2>().ToString() == "(0.00, 1.00)" && !upTask)
        {
            upTask = true;
            upInput.SetActive(false);
        }
        if (keybinds.Actions.FindAction("Movement").ReadValue<Vector2>().ToString() == "(-1.00, 0.00)" && !leftTask)
        {
            leftTask = true;
            leftInput.SetActive(false);
        }
        if (keybinds.Actions.FindAction("Movement").ReadValue<Vector2>().ToString() == "(0.00, -1.00)" && !downTask)
        {
            downTask = true;
            downInput.SetActive(false);
        }
        if (keybinds.Actions.FindAction("Movement").ReadValue<Vector2>().ToString() == "(1.00, 0.00)" && !rightTask)
        {
            rightTask = true;
            rightInput.SetActive(false);
        }
        if (upTask && leftTask && downTask && rightTask)
        {
            allowNextLine = true;
            interactInput.SetActive(true);
        }
        if (textComponent.text.Contains("punch") && !punchTask)
        {
            allowNextLine = false;
            interactInput.SetActive(false);
            punchInput.SetActive(true);
            if (keybinds.Actions.FindAction("Punch").IsInProgress())
            {
                punchTask = true;
                allowNextLine = true;
                punchInput.SetActive(false);
                interactInput.SetActive(true);
            }
        }
        if (textComponent.text.Contains("kick") && !kickTask)
        {
            allowNextLine = false;
            interactInput.SetActive(false);
            kickInput.SetActive(true);
            if (keybinds.Actions.FindAction("Kick").IsInProgress())
            {
                kickTask = true;
                allowNextLine = true;
                kickInput.SetActive(false);
                interactInput.SetActive(true);
            }
        }
        if (textComponent.text.Contains("grapple") && !grappleTask)
        {
            allowNextLine = false;
            interactInput.SetActive(false);
            grappleInput.SetActive(true);
            if (keybinds.Actions.FindAction("Grapple").IsInProgress())
            {
                grappleTask = true;
                allowNextLine = true;
                grappleInput.SetActive(false);
                interactInput.SetActive(true);
            }
        }
        if (textComponent.text.Contains("pause") && !pauseTask)
        {
            allowNextLine = false;
            interactInput.SetActive(false);
            pauseInput.SetActive(true);
            if (keybinds.Actions.FindAction("Pause").IsInProgress())
            {
                pauseTask = true;
                allowNextLine = true;
                pauseInput.SetActive(false);
                interactInput.SetActive(true);
            }
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
  
    public void SkipTutorial()
    {
        metCoach = true;
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
