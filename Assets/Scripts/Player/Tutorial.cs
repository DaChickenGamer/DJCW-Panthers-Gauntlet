using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialDialogueBox;
    public GameObject skipTutorialPopup;

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
        if (Dialogue.metCoach == false && !skipTutorialPopup.active)
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
        return "Null";
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
}
