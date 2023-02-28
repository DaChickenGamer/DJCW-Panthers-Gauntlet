using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    public static Animator animator;
    public Slider slider;

    [Header("Attack Hitboxes")]
    public GameObject Kick_Down;
    public GameObject Kick_Left, Kick_Right, Kick_Up, Punch_Down, Punch_Left, Punch_Right, Punch_Up;

    [Header("Grapple Meter")]
    public GameObject GrappleMeter;

    private float kickValue, attackDelay=0.25f,grappledelay;
    private float punchValue;

    [Header("Grapple Bools")]
    [SerializeField] private int grappleWinCounter = 0;
    [SerializeField] private bool inGrappleState = false;
    [HideInInspector] public bool grappled;

    [Header("Grapple Settings")]
    // Higher for harder characters
    [SerializeField] private float delay = 1f;
    [SerializeField] private float attackdelay;

    // Make wincount higher for harder characters
    [SerializeField] private int winCount = 100;

    // Makes the fight easier by giving the player a bigger saftey net
    [SerializeField] private int failCount = -10;

    [Header("Enemy")]
    public Collider2D enemycollider;

    private bool inputDelay = false;
    private void Start()
    {
        slider.value = (winCount + failCount) / 2;
        slider.maxValue = winCount; // Grappling Highest Amount
        slider.minValue = failCount; // Grappling Lowest Amount
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
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Gym") && enemycollider.gameObject.tag == "Enemy" && grappledelay <= 0 && !animator.GetBool("isKnocked"))
        {
                if (inGrappleState == false)
                {
                    grappleWinCounter = 0;
                    inGrappleState = true;
                    animator.SetBool("isGrapple", true);
                }
                else if (inGrappleState == true)
                {
                    Debug.Log("Grapple " + grappleWinCounter);
                    grappleWinCounter++;

                }
            }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Gym"))
        {
            slider.gameObject.SetActive(true);
            slider.value = grappleWinCounter;
            if (PlayerHealth.currentHealth <= 0)
            {
                animator.SetBool("isKnocked", true);
            }
            if (!animator.GetBool("isKnocked"))
            {
                if (grappledelay > 0)
                {
                    grappledelay -= Time.deltaTime;
                }

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
            }
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gym"))
        {
            slider.gameObject.SetActive(false);
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
                if(grappled) grappledelay = 2f;
                grappled = false;
                slider.gameObject.SetActive(false);
            }
    }
}
