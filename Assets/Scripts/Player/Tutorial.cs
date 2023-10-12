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
    public static bool movementKeysPressed; // Checks if all movement keys have been pressed

    // Colors For Flashing

    private Color32 normalColor = new Color32(255, 255, 255, 255);
    private Color32 transparentColor = new Color32(255, 255, 255, 150);


    // Keybinds 
    [Header("Keybinds")]
    [SerializeField] private InputActionReference movementInputActionReference;
    [SerializeField] private InputActionReference interactionInputActionReference;
    private InputAction movementInputAction;
    private InputAction interactionInputAction;

    private Coroutine typingCoroutine; // Stores the typing coroutine

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

        if (CoachDialogue.metCoach == false && !skipTutorialPopup.activeSelf)
        {
            MovementCheck();

            if (typingCoroutine == null)
            {

                tutorialDialogueBox.SetActive(true);
                if (!(DialogueStorage() == tutorialDialogueBox.GetComponentInChildren<TextMeshProUGUI>().text)) // Checks to see if the current dialouge is the same has the text component
                {
                    typingCoroutine = StartCoroutine(TypeLine(DialogueStorage()));
                }
                if (isTyping == false)
                    CurrentDialogue += 1;
            }
            else if (typingCoroutine != null && movedUp && movedDown && movedRight && movedLeft)
            {
                StopCoroutine(typingCoroutine);
                CurrentDialogue += 1;
                typingCoroutine = null;
            }
        }

    }
    private string DialogueStorage()
    {
        // Too add more you make a new case and you have to make sure the method is a string
        switch(CurrentDialogue)
        {
            case 0:
                return MovementDialogue();
            case 1:
                return "Use "
            + movementInputAction.GetBindingDisplayString()[0]
            + movementInputAction.GetBindingDisplayString()[4]
            + movementInputAction.GetBindingDisplayString()[2]
            + movementInputAction.GetBindingDisplayString()[6]
            + " to get over here I got a few things to say before you enter the ring!";
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
        return "Hey there fresh meat";
    }
    private string MovementDialogue()
    {
        return "Hey there fresh meat, welcome to the DJCW gym.";
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
        if (movedUp && movedDown && movedRight && movedLeft)
            CurrentDialogue += 1;

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
            movementKeysPressed = true;
            CurrentDialogue = 2;
        }
    }
    private string TalkToCoachCheck() // Step 2
    {
        // Tells the player how to interact ( interact with coach )

        if (CoachDialogue.InCoachArea && interactionInputAction.triggered)
        {
            firstInteractionWithCoach = true;
            PunchingBagPunchedCheck();
        }

        return "Great! Now use _ to chat with me.  You can also use _ to interact with other objects besides big ol' me";
        //Welcome to the DJCW.  I can't let you into the ring just yet.  Before you wrestle for your fame and glory you must show me that you are capable of landing a few good blows.
    }
    private string PunchingBagPunchedCheck() // Step 4
    {
        return "Alright! You see that bag over there?  That red one over there is giving me a funny look.  Go give it a big wallop for me using _";
        //Keep on punching it doesn't look like it's down yet
    }
    private string PunchingBagKickedCheck() // Step 5
    {
        return "Great Punches, but I don't think that bag learned it's lesson.  Give it a good beatdown with those legs of yours using _.";
        //Give it the good ol' left and right.
        //Thats more like it.
    }
    private string GrappledCheck() // Step 6
    {
        return "The heat is picking up.  Use _ to grab em to get a clean finish.  Renember keep pressing _ to win the grapple.";
        //drive em to the ground.
    }
        //That punching bag definitely won't make a comeback any time soon.
        //One last thing before you go.  You can use the ropes to make some high flyin moves if you charge at em.
        //Your now ready to enter the ring.  Good luck, don't get busted open.
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

        typingCoroutine = null;
    }

}
