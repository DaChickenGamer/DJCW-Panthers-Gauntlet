using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private Combat grappled;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (!animator.GetBool("isKnocked") && !animator.GetBool("isGrapple"))
        {
            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetFloat("X", movement.x);
                animator.SetFloat("Y", movement.y);

                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
    }

    
    private void FixedUpdate()
    {
        if (!animator.GetBool("isKnocked") && !animator.GetBool("isGrapple"))
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        if (!grappled)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
