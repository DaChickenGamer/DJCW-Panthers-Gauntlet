using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Punching : MonoBehaviour
{
    Animator animator;
    string currentState;

    const string Idle = "Idle";
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
        if (Input.GetMouseButtonDown(0) && (Input.GetKey(KeyCode.W)||Input.GetKeyUp(KeyCode.W))) ChangeAnimationState(Boxing_Up);
        else if (Input.GetKeyDown(KeyCode.W)) ChangeAnimationState(Walking_Up);
        else if (Input.GetKeyUp(KeyCode.W)) ChangeAnimationState(Idle);

        if (Input.GetMouseButtonDown(0) && (Input.GetKey(KeyCode.A)||Input.GetKeyUp(KeyCode.W))) ChangeAnimationState(Boxing_Left);
        else if (Input.GetKeyDown(KeyCode.A)) ChangeAnimationState(Walking_Left);
        else if (Input.GetKeyUp(KeyCode.A)) ChangeAnimationState(Idle_Left);

        if (Input.GetMouseButtonDown(0) && (Input.GetKey(KeyCode.S)||Input.GetKeyUp(KeyCode.S))) ChangeAnimationState(Boxing_Down);
        else if (Input.GetKeyDown(KeyCode.S)) ChangeAnimationState(Walking_Down);
        else if (Input.GetKeyUp(KeyCode.S)) ChangeAnimationState(Idle_Down);

        if (Input.GetMouseButtonDown(0) && (Input.GetKey(KeyCode.D)||Input.GetKeyUp(KeyCode.D))) ChangeAnimationState(Boxing_Right);
        else if (Input.GetKeyDown(KeyCode.D)) ChangeAnimationState(Walking_Right);
        else if (Input.GetKeyUp(KeyCode.D)) ChangeAnimationState(Idle_Right);
        
        
        
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
