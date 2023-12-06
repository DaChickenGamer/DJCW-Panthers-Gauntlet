using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;

    public static Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;

    private PlayerInputs playerInput;
    private InputAction movement;

    [SerializeField] private Combat grappled;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerInput = new PlayerInputs();
    }
    public void OnMovement(InputAction.CallbackContext ctxt)
    {
        direction = ctxt.ReadValue<Vector2>();

        if (!animator.GetBool("isKnocked") && !animator.GetBool("isGrapple"))
        {
            if (direction.x != 0 || direction.y != 0)
            {
                animator.SetFloat("X", direction.x);
                animator.SetFloat("Y", direction.y);

                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
    }
    private void Update()
    {
        if (!animator.GetBool("isKnocked") && !animator.GetBool("isGrapple"))
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        if (!grappled)
        {
            rb.velocity = Vector3.zero;
        }
    }

}
