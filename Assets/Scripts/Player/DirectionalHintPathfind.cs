using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;  //A* pathfinding definer

public class DirectionalHintPathfind : MonoBehaviour
{
    public Transform seeker;
    public Transform target;
    public LineRenderer lR;

    private List<Vector3> pathNodes = new List<Vector3>();

    private Seeker pathSeeker;
    private Path currentPath;
    private int currentWaypoint = 0;

    private void Start()
    {
        pathSeeker = GetComponent<Seeker>();

       
    }

    private void OnPathComplete(Path path)
    {
        //determines whether creating the path was succesful or not
        //
        if (!path.error)
        {
            currentPath = path;
            currentWaypoint = 0;
            pathNodes.Clear();

        //addsd all the nodes positions from the path to an array for later use
            foreach (Vector3 waypoint in path.vectorPath)
            {
                pathNodes.Add(waypoint);
            }

            UpdateLineRenderer();
        }
    }

    //Sets the amount of position for the lineRenderer based on the amount of nodes in the path
    //Uses the node positions stored in the pathNodes array from earlier to set the different positions for the line renderer
    private void UpdateLineRenderer()
    {
        lR.positionCount = pathNodes.Count;
        lR.SetPositions(pathNodes.ToArray());
    }

    private void Update()
    {
        //I have no idea what this is for
        //doesn't seem to change anything
        /*
        if (currentPath == null)
            return;

        if (currentWaypoint < pathNodes.Count)
        {
            float distance = Vector3.Distance(seeker.position, pathNodes[currentWaypoint]);
            if (distance < 2f) // You may adjust this threshold as needed
            {
                currentWaypoint++;
            }
        }
        */ 
        
        
        // Start pathfinding a path between the seeker and the target and then runs the function OnPathComplete()
        pathSeeker.StartPath(seeker.position, target.position, OnPathComplete);
    }
}
