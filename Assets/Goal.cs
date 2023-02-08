using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Transform ball; // Assign the ball's Transform component in the inspector
    public int score;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            score++;
            ball.position = Vector2.zero; // Set the ball's position to (0, 0)
        }
    }

}
