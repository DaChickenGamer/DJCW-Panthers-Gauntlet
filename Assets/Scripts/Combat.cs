using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    private Animator animator;

    private float kickValue;
    private float punchValue;

    private void Awake()
    {
       animator = GetComponent<Animator>();

    }
    private void OnPunch(InputValue value)
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
    private void OnKick(InputValue value)
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
