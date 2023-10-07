using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    // Popup and Actual box for the tutorial
    public GameObject tutorialDialogueBox;
    public GameObject skipTutorialPopup;

    private Vector2 playerDirection;

    // Different key gameobjects
    [Header("Flashing Key Objects")]
    [SerializeField] private GameObject flashingKeyUpImage;
    [SerializeField] private GameObject flashingKeyDownImage;
    [SerializeField] private GameObject flashingKeyLeftImage;
    [SerializeField] private GameObject flashingKeyRightImage;


    // Booleans For Checking
    private bool movedUp = false;
    private bool movedDown = false;
    private bool movedLeft = false;
    private bool movedRight = false;

    private bool flashOn = false; // For flashing

    private bool isFlashing  = false;
    private bool isTyping = false;

    private int CurrentDialogue;

    // Colors For Flashing

    private Color32 normalColor = new Color32(255, 255, 255, 255);
    private Color32 transparentColor = new Color32(255, 255, 255, 150);


    // Keybinds 
    [Header("Keybinds")]
    [SerializeField] private InputActionReference movementInputActionReference;
    [SerializeField] private InputActionReference interactionInputActionReference;
    private InputAction movementInputAction;
    private InputAction interactionInputAction;

    /*
    Tutorial Draft:

        1. Tell the player how to move
        2. Have the player talk to the coach
        3. The coach explains the different moves and how to use them
        4. The coach explains the KO bar and Meter

        - Maybe mention the leaderboard
    */

    private void Update()
    {
        playerDirection = PlayerMovement.direction;

        movementInputAction = movementInputActionReference.action;
        interactionInputAction = interactionInputActionReference.action;

        MovementFlashingKeys();

        if (Dialogue.metCoach == false && !skipTutorialPopup.activeSelf && !isTyping)
        {
            tutorialDialogueBox.SetActive(true);
            if (!(DialogueStorage(CurrentDialogue) == tutorialDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text)) // Checks to see if the current dialouge is the same has the text component
                StartCoroutine(TypeLine(DialogueStorage(CurrentDialogue)));
        }
    }
    private string DialogueStorage(int currentDialogue)
    {
        currentDialogue = CurrentDialogue; // So we can change the currentDialogue from other methods
        // Too add more you make a new case and you have to make sure the method is a string
        switch(currentDialogue)
        {
            case 0:
                return MovementCheck();
            case 1:
                return ExampleDialogue();
            case 2:
                return TalkToCoachCheck();
            default:
                return "No more text";
        }
    }

    /*
        Pure Text but we'll need

        - KO Bar Explaination // Step 7
        - KO Meter Explaniation // Step 3
    */
    private string ExampleDialogue()
    {
        return "Welcome Adventurer";
    }
    private string MovementCheck() // Step 1
    {
        if (playerDirection.y > 0)
        {
            movedUp = true;
            flashingKeyUpImage.SetActive(false);
        }
        if (playerDirection.y < 0)
        {
            movedDown = true;
            flashingKeyDownImage.SetActive(false);
        }
        if (playerDirection.x > 0) 
        {
            movedRight = true;
            flashingKeyRightImage.SetActive(false);
        }
        if (playerDirection.x < 0)
        {
            movedLeft = true;
            flashingKeyLeftImage.SetActive(false);
        }

        return "Movement Check Placeholder";
    }
    private void MovementFlashingKeys()
    {
        // Need to tell the player how to move

        if ((!movedUp || !movedDown || !movedLeft || !movedRight) && isFlashing == false) // Makes keys flash if not true
        {
            StartCoroutine(FlashKeys());
        }
        else if (isFlashing == false)
        {
            CurrentDialogue = 2;
        }
    }
    private string TalkToCoachCheck() // Step 2
    {
        // Tells the player how to interact ( interact with coach )

        if (Dialogue.InCoachArea && interactionInputAction.triggered)
        {
            PunchingBagPunchedCheck();
        }

        return "Talk to coach placeholder";
    }
    private void PunchingBagPunchedCheck() // Step 4
    {

    }
    private void PunchingBagKickedCheck() // Step 5
    {

    }
    private void GrappledCheck() // Step 6
    {

    }

    private IEnumerator FlashKeys()
    {
        isFlashing = true;

        // W / A / S / D
        // 0 1 2 3 4 5 6

        // When we support multiple platforms we can also add a variable for platform
        // The variable will be the folder of the platform name

        flashingKeyUpImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Art/Sprites/KeyBinds/Keyboard/Keyboard_" + movementInputAction.GetBindingDisplayString()[0] + "_Pressed.png");
        flashingKeyDownImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Art/Sprites/KeyBinds/Keyboard/Keyboard_" + movementInputAction.GetBindingDisplayString()[4] + "_Pressed.png");
        flashingKeyLeftImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Art/Sprites/KeyBinds/Keyboard/Keyboard_" + movementInputAction.GetBindingDisplayString()[2] + "_Pressed.png");
        flashingKeyRightImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Art/Sprites/KeyBinds/Keyboard/Keyboard_" + movementInputAction.GetBindingDisplayString()[6] + "_Pressed.png");

        if (flashOn)
        {
            flashingKeyUpImage.GetComponent<Image>().color = normalColor;
            flashingKeyDownImage.GetComponent<Image>().color = normalColor;
            flashingKeyLeftImage.GetComponent<Image>().color = normalColor;
            flashingKeyRightImage.GetComponent<Image>().color = normalColor;
            flashOn = false;
        }
        else
        {
            flashingKeyUpImage.GetComponent<Image>().color = transparentColor;
            flashingKeyDownImage.GetComponent<Image>().color = transparentColor;
            flashingKeyLeftImage.GetComponent<Image>().color = transparentColor;
            flashingKeyRightImage.GetComponent<Image>().color = transparentColor;
            flashOn = true;
        }

        yield return new WaitForSeconds(1.0f);

        isFlashing = false;
    }
    private IEnumerator TypeLine(string dialogue)
    {
        isTyping = true;
        tutorialDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = ""; // Clear the text

        for (int i = 0; i < dialogue.Length; i++)
        {
            tutorialDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text += dialogue[i];
            yield return new WaitForSeconds(0.1f);
        }

        isTyping = false; // Set to false when typing is complete
    }

}
