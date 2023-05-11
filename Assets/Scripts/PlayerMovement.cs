using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;

    private Vector2 movement;
    private Rigidbody2D rb;
    public int spin = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(left))
        {
            speed = 15;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            rb.rotation += -speed;
        }
        else if (Input.GetKeyDown(right))
        {
            speed = 15;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            rb.rotation += speed;
        }
        else if (Input.GetKeyDown(up))
        {
            speed = 15;
            rb.velocity = new Vector2(rb.velocity.y, speed);
        }
        else if (Input.GetKeyDown(down))
        {
            speed = 15;
            rb.velocity = new Vector2(-rb.velocity.y ,- speed);
        }
        else if (!Input.GetKey(right) && !Input.GetKey(up) && !Input.GetKey(left) && !Input.GetKey(down)) 
        {
            speed = 0;
            rb.velocity = Vector2.zero;
            rb.rotation +=0;
        }
    }
    private void FixedUpdate()
    {
        rb.rotation += spin;
    }
}
