using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMethods : MainMenu
{
    
    public Rigidbody2D rb;
    [Header("Movement")]
    [SerializeField] private int x; //Amount moved per second
    private float StopMotionTimer;
    private float startingPosition; //Stores Object's start Location
    [SerializeField] private float positionIncrement;   //The Amount that adds on to the startingPosition to get the endPosition
    private float endingPosition;   //Stores Object's End Location
    private float currentPosition;  //Stores Current location

    private bool animationComplete;

    private bool MoveRight, MoveLeft, checkedStartingPosition = false;



    private Animator anim;
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    private void Timer()
    {
        if(StopMotionTimer>0)
        {
            StopMotionTimer+=Time.deltaTime;
        }
        if(StopMotionTimer<=0)
        rb.velocity = new Vector2(0, 0);
    }

    //Stores starting positon and then calculates end position
    private void CheckPositon()
    {
        if(checkedStartingPosition == false)
        {
            startingPosition = transform.position.x;
            endingPosition = startingPosition += positionIncrement;
            Debug.Log("StartingPosition: " + startingPosition + " EndingPosition: " + endingPosition);

            //checkedStartingPosition = true;
        }
    }

    public void MoveObjectRight()
    {
        MoveRight = true;
        MoveLeft = false;
    }

    public void MoveObjectLeft()
    {
        MoveRight = false;
        MoveLeft = true;
    }
    
    void Update() 
    {
        if(animationComplete == true)
        {   
            Debug.Log("Joe");
            CheckPositon();
            Timer();
        
            currentPosition = transform.position.x;

            //Move Left Detection
            if(MoveLeft == true & (currentPosition <= startingPosition))
            {
   
                rb.velocity = new Vector2(0, 0);
            }   
            else
            {
                 Debug.Log("MoveLeft");
                rb.velocity = new Vector2(-x, 0);
                StopMotionTimer=3;  
            }
            
            //MoveRight Dectection
            if(MoveRight == true & (currentPosition >= endingPosition))
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
    }
}
