using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGoal : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnLocation;
    public Quaternion spawnRotation;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            Score.redTeamScore++;
            Instantiate(ball, spawnLocation.position, spawnRotation);
            Destroy(collider.gameObject);
        }
    }

}
