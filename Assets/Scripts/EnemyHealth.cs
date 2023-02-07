using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    /*Animator animator;
    string currentState;

    const string Idle = "Idle";
    const string Punched = "Punched";*/
    public static float knocked = -1;
    /*public GameObject knockedOut; //Select the "projectile" object to spawn
    public Transform spawnLocation; //Location to spawn "projectile"
    public Quaternion spawnRotation; // Rotaion of "projectile"*/
    int health = 100;
    public void TakeDamage(int damage)
    {
        
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            knocked++;
            Debug.Log("Knockout");
            
            //Instantiate(knockedOut, spawnLocation.position, spawnRotation);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        /*ChangeAnimationState(Idle);
        animator = GetComponent<Animator>();*/
    }
    public void Update()
    {
        //ChangeAnimationState(Punched);
    }
    void ChangeAnimationState(string newState)
    {
        //Stop animation from interrupting itself
        /*if (currentState == newState) return;

        // Plays new animation
        animator.Play(newState);



        //Update current state
        currentState = newState;*/
    }
}
