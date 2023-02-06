using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Couch : MonoBehaviour
{
    Animator animator;
    string currentState;

    const string Waving = "";
    public TextMeshProUGUI Speech;
    public bool Movement=true,W,A,S,D,Kick,Block;
    public float TextTimer;
    // Start is called before the first frame update
    void Start()
    {
        //ChangeAnimationState(Waving);
        Speech.text = "Use Left Click(Mouse), A(Controller) To Punch";
        TextTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (TextTimer > 0)
        {
            TextTimer-=Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && TextTimer <= 0&&Movement)
        {
            Speech.text = "Use WASD(Keyboard), Left Stick(Controller) To Move";
            TextTimer = 3;
            Movement = false;
            Kick = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
            W = true;
        if (Input.GetKeyDown(KeyCode.A))
            A = true;
        if (Input.GetKeyDown(KeyCode.S))
            S = true;
        if (Input.GetKeyDown(KeyCode.D))
            D = true;
        if (W && A && S && D && TextTimer <= 0&&Kick)
        {
            TextTimer = 3;
            Speech.text = "Use Right Click(Mouse), B(Controller) To Kick";
            Kick=false;
            Block = true;
        }
        if (Input.GetMouseButtonDown(1)&&TextTimer<=0&&Block)
        {
            Speech.text = "Use Middle Click(Mouse), Y(Controller) To Block";
            TextTimer = 3;
            Block = false;
        }
    }
    void ChangeAnimationState(string newState)
    {
        //Stop animation from interrupting itself
        if (currentState == newState) return;

        // Plays new animation
        animator.Play(newState);



        //Update current state
        currentState = newState;
    }
}
