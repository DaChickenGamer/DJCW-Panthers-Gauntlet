using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineToCoach : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject coach;
    void Update()
    {
        Vector3 direction = coach.transform.position - gameObject.transform.position;

        lineRenderer.SetPosition(0, gameObject.transform.position);

        if (Tutorial.firstInteractionWithCoach == false && Tutorial.movementKeysPressed)
        {
            if (Physics.Raycast(gameObject.transform.position, direction, out RaycastHit hitInfo, direction.magnitude))
            {
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(1, coach.transform.position);
            }
        }
        else if (Tutorial.movementKeysPressed && Tutorial.movementKeysPressed)
            lineRenderer.enabled = false;
    }
}
