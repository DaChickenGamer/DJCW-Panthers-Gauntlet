using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTutorialCode : MonoBehaviour
{
    void Start()
    {
        // Makes the Skip Tutorial no longer visible if you already talked to the coach
        // Also makes it so we can hide it in the inspector

        if (Dialogue.metCoach == false)
            transform.GetChild(0).gameObject.SetActive(true);
        else
            transform.GetChild(0).gameObject.SetActive(false);
    }
}
