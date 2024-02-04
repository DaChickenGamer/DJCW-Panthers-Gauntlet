using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using BehaviorDesigner.Runtime.Tasks;

public class EnemyAi : Action
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    bool isPathUpdate = false;

    Seeker seeker;
    Rigidbody2D rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        StartCouroutine(UpdatePath(.5));
    }

    private IEnumerator UpdatePath(float waitTime)
    {
        while (isPathUpdate)
        {
            isPathUpdate = true;
            if (seeker.IsDone()) 
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            yield return WaitForSeconds(waitTime);
            isPathUpdate = false;
        }
    }

    void OnPathComplete(Path p)
    {
        
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;   
        }
    }

    void FixedUpdate()
    {
        
        if (path == null )
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        Debug.Log(force);
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
