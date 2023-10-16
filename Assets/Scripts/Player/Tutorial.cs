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
using static UnityEngine.UIElements.UxmlAttributeDescription;

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
    [SerializeField] private GameObject flashingInteractingImage;

    // The amount of times the player has done the action
    private int punchAmount;
    private int kickAmount;
    private int grappleAmount;

    // Booleans For Checking
    private bool movedUp = false;
    private bool movedDown = false;
    private bool movedLeft = false;
    private bool movedRight = false;

    private bool flashOn = false; // For flashing

    private bool isFlashing  = false;
    private bool isTyping = false;

    private int CurrentDialogue = 0;

    public static bool firstInteractionWithCoach = false;

    private bool flashingKeysSetActive = false; // Checks if the keys have been set active yet

    private bool skippedMovement = false; // Checks to see if the movement has been skipped
    private bool skippedPunching = false;
    private bool skippedKicking = false;
    private bool skippedGrapple = false;
    private bool skippedCoach = false;

    private bool interactFlashing = false; // Flashes the interact key

    // Colors For Flashing

    private Color32 normalColor = new Color32(255, 255, 255, 255);
    private Color32 transparentColor = new Color32(255, 255, 255, 150);


    // Keybinds 
    [Header("Keybinds")]
    [SerializeField] private InputActionReference movementInputActionReference;
    [SerializeField] private InputActionReference interactionInputActionReference;

    [SerializeField] private InputActionReference punchInputActionReference;
    [SerializeField] private InputActionReference kickInputActionReference;
    [SerializeField] private InputActionReference grappleInputActionReference;

    private InputAction movementInputAction;
    private InputAction interactionInputAction;

    private InputAction punchInputAction;
    private InputAction kickInputAction;
    private InputAction grappleInputAction;

    private Coroutine typingCoroutine; // Stores the typing coroutine


    // Punching Bag For Checking

    private Collider2D punchingBag;

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

        punchInputAction = punchInputActionReference.action;
        kickInputAction = kickInputActionReference.action;
        grappleInputAction = grappleInputActionReference.action;

        if (CoachDialogue.metCoach == false && !skipTutorialPopup.activeSelf)
        {

            if (typingCoroutine == null)
            {

                tutorialDialogueBox.SetActive(true);
                if (!(DialogueStorage() == tutorialDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text) && CurrentDialogue != 9) // Checks to see if the current dialouge is the same has the text component
                {
                    typingCoroutine = StartCoroutine(TypeLine(DialogueStorage()));
                }
                if (isTyping == false && (CurrentDialogue == 0 || CurrentDialogue == 5 || CurrentDialogue == 7 || CurrentDialogue == 8) && Keyboard.current.anyKey.wasPressedThisFrame)
                    CurrentDialogue += 1;
            }
            SkipDialogue();
        }
        if (CurrentDialogue != 0 && CurrentDialogue != 5 && CurrentDialogue != 7 && CurrentDialogue != 8)
            DialogueFunctions();
    }
    private string DialogueStorage()
    {
        // Too add more you make a new case and you have to make sure the method is a string
        switch(CurrentDialogue)
        {
            case 0:
                return "Hey there fresh meat, welcome to the DJCW gym.";
            case 1:
                return "Use "
            + movementInputAction.GetBindingDisplayString()[0] // W
            + movementInputAction.GetBindingDisplayString()[2] // A
            + movementInputAction.GetBindingDisplayString()[4] // S
            + movementInputAction.GetBindingDisplayString()[6] // D
            + " to get over here I got a few things to say before you enter the ring!";
            case 2:
                return "Great! Now use " + interactionInputAction.GetBindingDisplayString()[0] + " to chat with me. You can also use " + interactionInputAction.GetBindingDisplayString()[0] + " to interact with other objects besides big ol' me.";
            case 3:
                return "Alright! You see that bag over there? That red one over there is giving me a funny look. Go give it a big wallop for me using " + punchInputAction.GetBindingDisplayString()[0] + ".";
            case 4:
                return "Great Punches, but I don't think that bag learned it's lesson. Give it a good beatdown with those legs of yours using " + kickInputAction.GetBindingDisplayString()[0] + ".";
            case 5:
                return "Placeholder Grapple Meter Text"; // Need to explain Grapple Meter
            case 6:
                return "The heat is picking up. Use " + grappleInputAction.GetBindingDisplayString()[0] + " to grab em to get a clean finish. Remember keep pressing " + grappleInputAction.GetBindingDisplayString()[0] + " to win the grapple.";
            case 7:
                return "Placeholder KO Bar Text"; // Need to explain KO Bar
            case 8:
                return "You did pretty well. You're ready to enter the ring.";
            default:
                Debug.LogError("Inaccessible Dialogue Text");
                return "No more text";
        }
    }
    private void DialogueFunctions()
    {
        switch(CurrentDialogue)
        {
            case 1:
                ActivateMovment();
                break;
            case 2:
                TalkToCoachCheck();
                break;
            case 3:
                PunchingBagPunchedCheck();
                break;
            case 4:
                PunchingBagKickedCheck();
                break;
            case 6:
                GrappledCheck();
                break;
            case 9:
                ExitDialogue();
                break;
            default:
                Debug.LogError("Inaccessible Dialogue Function");
                break;
        }
    }

    private void SkipDialogue()
    {
        if (typingCoroutine != null && movedUp && movedDown && movedRight && movedLeft && skippedMovement == false)
        {
            StopCoroutine(typingCoroutine);
            CurrentDialogue = 2; // Don't change this number needed to function ( unless reassigning the dialogue )
            typingCoroutine = null;
            skippedMovement = true;
        }
        if (typingCoroutine != null && skippedPunching == false && CurrentDialogue == 3 && punchAmount >= 5)
        {
            StopCoroutine(typingCoroutine);
            CurrentDialogue += 1;
            typingCoroutine = null;
            skippedPunching = true;
        }
        if (typingCoroutine != null && skippedKicking == false && CurrentDialogue == 4 && kickAmount >= 5)
        {
            StopCoroutine(typingCoroutine);
            CurrentDialogue += 1;
            typingCoroutine = null;
            skippedKicking = true;
        }
        if (typingCoroutine != null && skippedGrapple == false && CurrentDialogue == 6 && grappleAmount >= 3)
        {
            StopCoroutine(typingCoroutine);
            CurrentDialogue += 1;
            typingCoroutine = null;
            skippedGrapple = true;
        }
    }
    /*
        Pure Text but we'll need

        - KO Bar Explaination // Step 7
        - KO Meter Explaniation // Step 3
    */

    private void ActivateMovment()
    {
        if (flashingKeysSetActive == false)
        {
            flashingKeyDownImage.SetActive(true);
            flashingKeyUpImage.SetActive(true);
            flashingKeyRightImage.SetActive(true);
            flashingKeyLeftImage.SetActive(true);

            flashingKeysSetActive = true;
        }

        if ((!movedUp || !movedDown || !movedLeft || !movedRight) && isFlashing == false) // Makes keys flash if not true
        {
            StartCoroutine(FlashKeys());
        }

        MovementCheck();
    }
    private void MovementCheck() // Step 1
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
        if (movedUp && movedDown && movedRight && movedLeft && skippedMovement == false)
            CurrentDialogue = 2;
    }

    private void TalkToCoachCheck() // Step 2
    {
        // Checks to see when the player interacted with the coach

        flashingInteractingImage.SetActive(true);

        interactFlashing = true;

        if (isFlashing == false)
            StartCoroutine(FlashKeys());

        if (CoachDialogue.InCoachArea && interactionInputAction.triggered)
        {
            flashingInteractingImage.SetActive(false);
            interactFlashing = false;
            CurrentDialogue += 1;
        }
    }
    private void PunchingBagPunchedCheck() // Step 4
    {
        /*
        Need for later:

        punchingBag.IsTouching(fist)

        Don't have combat system but when we do this needs to be added
        */

        if (punchInputAction.triggered && punchAmount < 5)
            punchAmount++;
        else if (punchAmount >= 5)
            CurrentDialogue += 1;
    }
    private void PunchingBagKickedCheck() // Step 5
    {
        /*
        Need for later:

        punchingBag.IsTouching(kick)

        Don't have combat system but when we do this needs to be added
        */

        if (kickInputAction.triggered && kickAmount < 5)
            kickAmount++;
        else if (kickAmount >= 5)
            CurrentDialogue += 1;
    }
    private void GrappledCheck() // Step 6
    {
        /*
        Need for later:

        punchingBag.IsTouching(grapple)

        Don't have combat system but when we do this needs to be added
        */

        if (grappleInputAction.triggered && grappleAmount < 3)
            grappleAmount++;
        else if (grappleAmount >= 3)
            CurrentDialogue += 1;
    }
    private void ExitDialogue()
    {
        tutorialDialogueBox.SetActive(false);
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

        flashingInteractingImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Art/Sprites/KeyBinds/Keyboard/Keyboard_" + interactionInputAction.GetBindingDisplayString()[0] + "_Pressed.png");

        if (flashOn)
        {
            if (movedDown == false || movedUp == false || movedRight == false || movedLeft == false)
            {
                flashingKeyUpImage.GetComponent<Image>().color = normalColor;
                flashingKeyDownImage.GetComponent<Image>().color = normalColor;
                flashingKeyLeftImage.GetComponent<Image>().color = normalColor;
                flashingKeyRightImage.GetComponent<Image>().color = normalColor;
                flashOn = false;
            }
            if (interactFlashing)
            {
                flashingInteractingImage.GetComponent<Image>().color = normalColor;
                flashOn = false;
            }
        }
        else
        {
            if (movedDown == false || movedUp == false || movedRight == false || movedLeft == false)
            {
                flashingKeyUpImage.GetComponent<Image>().color = transparentColor;
                flashingKeyDownImage.GetComponent<Image>().color = transparentColor;
                flashingKeyLeftImage.GetComponent<Image>().color = transparentColor;
                flashingKeyRightImage.GetComponent<Image>().color = transparentColor;
                flashOn = true;
            }
            if (interactFlashing)
            {
                flashingInteractingImage.GetComponent<Image>().color = transparentColor;
                flashOn = true;
            }
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

        typingCoroutine = null;
    }

}
