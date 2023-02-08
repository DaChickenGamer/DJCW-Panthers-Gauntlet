using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGoal : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnLocation;
    public Quaternion spawnRotation;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            //Score.RedTeamScore++;
            Destroy(ball);
            Instantiate(ball, spawnLocation.position, spawnRotation);

        }
    }

}
