using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.UI;
public class Combat : MonoBehaviour
{
    public static Animator animator;
    public Slider slider;

    public GameObject Kick_Down, Kick_Left, Kick_Right, Kick_Up, Punch_Down, Punch_Left, Punch_Right, Punch_Up, GrappleMeter;
    public Transform spawnLocation;
    public Quaternion spawnRotation;

    private float kickValue, attackDelay=0.25f;
    private float punchValue;

    [SerializeField] private int grappleWinCounter = 0;
    [SerializeField] private bool inGrappleState = false,grappled;

    // Higher for harder characters
    [SerializeField] private float delay = 1f,attackdelay;

    // Make wincount higher for harder characters
    [SerializeField] private int winCount = 10;

    // Makes the fight easier by giving the player a bigger saftey net
    [SerializeField] private int failCount = -10;
    public Collider2D enemycollider;

    private bool inputDelay = false;
    private void Start()
    {
        slider.maxValue = winCount;
        slider.minValue = failCount;
        spawnLocation=GameObject.FindObjectOfType<Transform>();
    }
    private void Awake()
    {
       animator = GetComponent<Animator>();

    }
    private void OnPunch(InputValue value)
    {
        if (!animator.GetBool("isKnocked")&&!animator.GetBool("isGrapple"))
        {
            punchValue = value.Get<float>();

            if (punchValue != 0)
            {
                animator.SetBool("isPunching", true);
            }
            else
            {
                animator.SetBool("isPunching", false);
            }
            Debug.Log("Punched");
        }
    }
    private void OnKick(InputValue value)
    {
        if (!animator.GetBool("isKnocked")&&!animator.GetBool("isGrapple"))
        {
            kickValue = value.Get<float>();

            if (kickValue != 0)
            {
                animator.SetBool("isKicking", true);
            }
            else
            {
                animator.SetBool("isKicking", false);
            }
            Debug.Log("Kicked");
        }
    }
    private void OnGrapple(InputValue value)
    {
        if (enemycollider.gameObject.tag == "Enemy")
        {
            if (!animator.GetBool("isKnocked"))
            {
                animator.SetBool("isGrapple", true);
                if (inGrappleState == false)
                {
                    grappleWinCounter = 0;
                    inGrappleState = true;
                }
                else if (inGrappleState == true)
                {
                    Debug.Log("Grapple " + grappleWinCounter);
                    grappleWinCounter++;

                }
            }
        }
    }
    void Update()
    {
        slider.value = grappleWinCounter;
        if (PlayerHealth.currentHealth<=0)
        {
            animator.SetBool("isKnocked", true);
        }
        if (!animator.GetBool("isKnocked"))
        {
            
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            if (inGrappleState == true)
            {
                if (grappleWinCounter >= winCount)     //detects player's success in grapple
                {
                    Debug.Log("You won the grapple");
                    grappleWinCounter = 0;
                    inGrappleState = false;
                    animator.SetBool("isGrapple", false);
                }

                if (grappleWinCounter <= failCount)    //detects player's falure in grapple
                {
                    Debug.Log("You lossed the grapple");
                    grappleWinCounter = 0;
                    inGrappleState = false;
                    animator.SetBool("isGrapple", false);
                }

                if (inputDelay == false) //delays bot input
                {
                    StartCoroutine(BotDelay());
                    inputDelay = true;
                }


            }
            IEnumerator BotDelay()      //delays value addition
            {
                yield return new WaitForSeconds(delay);

                grappleWinCounter--;
                Debug.Log("Grapple " + grappleWinCounter);
                inputDelay = false;
            }
            if (attackdelay <= 0)
            {
                if (animator.GetBool("isPunching"))
                {
                    if (animator.GetFloat("X") > 0)
                    {
                        Instantiate(Punch_Right, this.transform); attackdelay = attackDelay;
                    }
                    if (animator.GetFloat("X") < 0)
                    {
                        Instantiate(Punch_Left, this.transform); attackdelay = attackDelay;
                    }
                    if (animator.GetFloat("Y") > 0)
                    {
                        Instantiate(Punch_Up, this.transform); attackdelay = attackDelay;
                    }
                    if (animator.GetFloat("Y") < 0)
                    {
                        Instantiate(Punch_Down, this.transform); attackdelay = attackDelay;
                    }
                }
                if (animator.GetBool("isKicking"))
                {
                    if (animator.GetFloat("X") > 0)
                    {
                        Instantiate(Kick_Right, this.transform); attackdelay = attackDelay;
                    }
                    if (animator.GetFloat("X") < 0)
                    {
                        Instantiate(Kick_Left, this.transform); attackdelay = attackDelay;
                    }
                    if (animator.GetFloat("Y") > 0)
                    {
                        Instantiate(Kick_Up, this.transform); attackdelay = attackDelay;
                    }
                    if (animator.GetFloat("Y") < 0)
                    {
                        Instantiate(Kick_Down, this.transform); attackdelay = attackDelay;
                    }
                }
            }
            if (animator.GetBool("isGrapple"))
            {
                if (!grappled)
                {
                    slider.gameObject.SetActive(true);
                    grappled = true;
                    animator.SetBool("isWalking", false);
                }
            }
            if (!animator.GetBool("isGrapple"))
            {
                grappled = false;
                slider.gameObject.SetActive(false);
            }
        }
    }
}
