using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMethods : MonoBehaviour
{
    
    public Rigidbody2D rb;
    [Header("Movement")]
    [SerializeField] private int x; //Amount moved per second
    private float StopMotionTimer;
    private float startingPosition; //Stores Object's start Location
    [SerializeField] private float positionIncrement;   //The Amount that adds on to the startingPosition to get the endPosition
    private float endingPosition;   //Stores Object's End Location
    private float currentPosition;  //Stores Current location
    private Animator anim;
    
    void Update() 
    {
        if(StopMotionTimer>0)
        {
            StopMotionTimer+=Time.deltaTime;
        }
        if(StopMotionTimer<=0)
        rb.velocity = new Vector2(0, 0);
        
        currentPosition = transform.position.x;
    }

    private void Awake() 
    {
        startingPosition = transform.position.x;
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        //Stores starting positon and then calculates end position
        endingPosition = startingPosition += positionIncrement;
        Debug.Log("StartingPosition: " + startingPosition + " EndingPosition: " + endingPosition);
    }
    public void MoveObjectRight()
    {
        if(currentPosition > endingPosition)
        {
            rb.velocity = new Vector2(0, 0);
        }   
        else
        {
            rb.velocity = new Vector2(x, 0);
            StopMotionTimer=3;
            Debug.Log("MoveRight");   
        }
    }

    public void MoveObjectLeft()
    {
        Debug.Log("MoveLeft");
        if(currentPosition > startingPosition)
        {
            rb.velocity = new Vector2(-x, 0);
            StopMotionTimer=3;     
        }   
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    
}
