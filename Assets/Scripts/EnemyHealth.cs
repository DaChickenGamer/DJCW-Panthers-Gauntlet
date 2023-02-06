using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator animator;
    string currentState;

    const string Idle = "";
    const string Punched = "";
    public static float knocked = -1;
    public GameObject knockedOut; //Select the "projectile" object to spawn
    public Transform spawnLocation; //Location to spawn "projectile"
    public Quaternion spawnRotation; // Rotaion of "projectile"
    int health = 100;
    public void TakeDamage(int damage)
    {
        ChangeAnimationState(Punched);
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            knocked++;
            Debug.Log("Knockout");
            
            Instantiate(knockedOut, spawnLocation.position, spawnRotation);
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        ChangeAnimationState(Idle);
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
