using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    // Colors For Flashing

    private Color32 normalColor = new Color32(255, 255, 255, 255);
    private Color32 transparentColor = new Color32(255, 255, 255, 150); 


    /*
    Tutorial Draft:

        1. Tell the player how to move
        2. Have the player talk to the coach
        3. The coach explains the different moves and how to use them
        4. The coach explains the KO bar and Meter

        - Maybe mention the leaderboard
    */


    // Update is called once per frame
    private void Update()
    {
        playerDirection = PlayerMovement.direction;

        MovementFlashingKeys();

        if (Dialogue.metCoach == false && !skipTutorialPopup.activeSelf)
        {
            tutorialDialogueBox.SetActive(true);
            DialogueStorage(1);
        }
    }
    private string DialogueStorage(int currentDialogue)
    {
        switch(currentDialogue)
        {
            case 1:
                return MovementCheck();
            default:
                return "No more text";
        }
    }
    
    /*
        Pure Text but we'll need

        - KO Bar Explaination // Step 7
        - KO Meter Explaniation // Step 3
    */

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

        return "Null";
    }
    private void MovementFlashingKeys()
    {
        if ((!movedUp || !movedDown || !movedLeft || !movedRight) && !isFlashing) // Makes keys flash if not true
        {
            StartCoroutine(FlashKeys());
        }
    }
    private string TalkToCoachCheck() // Step 2
    {
        return "Null";
    }
    private string PunchingBagPunchedCheck() // Step 4
    {
        return "Null";
    }
    private string PunchingBagKickedCheck() // Step 5
    {
        return "Null";
    }
    private string GrappledCheck() // Step 6
    {
        return "Null";
    }

    private IEnumerator FlashKeys()
    {
        isFlashing = true;

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
}
