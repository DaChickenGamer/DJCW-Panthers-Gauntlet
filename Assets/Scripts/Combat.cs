using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    private Animator animator;

    private Vector2 kickValue;
    private Vector2 punchValue;

    private void Awake()
    {
       animator = GetComponent<Animator>();

    }
    private void OnPunch(InputValue value)
    {
        punchValue = value.Get<Vector2>();

        if (punchValue.x != 0 || punchValue.y != 0)
        {
            animator.SetFloat("X", punchValue.x);
            animator.SetFloat("Y", punchValue.y);

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
        kickValue = value.Get<Vector2>();

        if (kickValue.x != 0 || kickValue.y != 0)
        {
            animator.SetFloat("X", kickValue.x);
            animator.SetFloat("Y", kickValue.y);

            animator.SetBool("isKicking", true);
        }
        else
        {
            animator.SetBool("isKicking", false);
        }
        Debug.Log("Kicked");
    }

}
