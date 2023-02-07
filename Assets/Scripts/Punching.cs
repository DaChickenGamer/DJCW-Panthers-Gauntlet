using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Punching : MonoBehaviour
{
    private bool W, A, S, D;
    Animator animator;
    string currentState;

    const string Idle_Up = "Idle";
    const string Boxing_Up = "Boxing_Up";
    const string Boxing_Right = "Boxing_Right";
    const string Boxing_Left = "Boxing_Left";
    const string Boxing_Down = "Boxing_Down";
    const string Walking_Down = "Walking_Down";
    const string Walking_Right = "Walking_Right";
    const string Walking_Left = "Walking_Left";
    const string Walking_Up = "Walking_Up";
    const string Idle_Left = "Idle_Left";
    const string Idle_Right = "Idle_Right";
    const string Idle_Down = "Idle_Down";
    private int damage = 5;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && W) ChangeAnimationState(Boxing_Up);
        else if (Input.GetKeyDown(KeyCode.W)) { ChangeAnimationState(Walking_Up); W = true; A = false; S = false; D = false; }
        else if (Input.GetMouseButtonUp(0) && W) ChangeAnimationState(Idle_Up);

        else if (Input.GetMouseButtonDown(0) && A) ChangeAnimationState(Boxing_Left);
        else if (Input.GetKeyDown(KeyCode.A)) { ChangeAnimationState(Walking_Left); W = false; A = true; S = false; D = false; }
        else if (Input.GetMouseButtonUp(0) && A) ChangeAnimationState(Idle_Left);

        else if (Input.GetMouseButtonDown(0) && S) ChangeAnimationState(Boxing_Down);
        else if (Input.GetKeyDown(KeyCode.S)) { ChangeAnimationState(Walking_Down); W = false; A = false; S = true; D = false; }
        else if (Input.GetMouseButtonUp(0) && S) ChangeAnimationState(Idle_Down);

        else if (Input.GetMouseButtonDown(0) && D) ChangeAnimationState(Boxing_Right);
        else if (Input.GetKeyDown(KeyCode.D)) { ChangeAnimationState(Walking_Right); W = false; A = false; S = false; D = true; }
        else if (Input.GetMouseButtonUp(0) && D) ChangeAnimationState(Idle_Right);

        else if (Input.GetKeyUp(KeyCode.W)&&(!A||!S||!D)) ChangeAnimationState(Idle_Up);
        else if (Input.GetKeyUp(KeyCode.A)&&(!W||!S||!D)) ChangeAnimationState(Idle_Left);
        else if (Input.GetKeyUp(KeyCode.S)&&(!W||!A||!D)) ChangeAnimationState(Idle_Down);
        else if (Input.GetKeyUp(KeyCode.D)&&(!W||!A||!S)) ChangeAnimationState(Idle_Right);
        
        
        
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        EnemyHealth enemy = collider.GetComponent<EnemyHealth>();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("pressed");
            if (collider.gameObject.tag == "Enemy")
            {
                Debug.Log("enemy found");
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            
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
