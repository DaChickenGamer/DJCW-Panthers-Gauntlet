using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    private bool attack = false, attacktiming=false, move;
    [SerializeField] private float speed=4f;
    private float timing, stopattack,attackDelay;
    private int damage=5;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
        FollowPlayer();
        move=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Combat.animator.GetBool("isGrapple"))
        {
            animator.SetBool("isGrapple", true);
            StopPlayer();
        }
        if (!Combat.animator.GetBool("isGrapple"))
        {
            animator.SetBool("isGrapple",false);
        }
        if (EnemyHealth.health <= 0)
        {
            animator.SetBool("isKnocked", true);
        }
        if (!animator.GetBool("isKnocked") && !animator.GetBool("isGrapple"))
        {
            if (move == true)
            {
                FollowPlayer();
            }
            if (attackDelay > 0 && attack == false)
            {
                attackDelay -= Time.deltaTime;
            }
            if (attack == true)
            {

                animator.SetBool("isAttacking", true);
                timing += Time.deltaTime;
                if (timing >= 1)
                {
                    attack = false;
                    animator.SetBool("isAttacking", false);
                    timing = 0;
                }
            }
            if (attacktiming == true)
            {
                stopattack += Time.deltaTime;
                if (stopattack >= 4)
                {
                    stopattack = 0;
                    attack = false;
                    attacktiming = false;
                }
            }
        }
    }
    public void FollowPlayer()
    {
        if (!animator.GetBool("isKnocked") && !animator.GetBool("isGrapple"))
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("moveX", (target.position.x - transform.position.x));
            animator.SetFloat("moveY", (target.position.y - transform.position.y));
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
    public void StopPlayer()
    {
        if (!animator.GetBool("isKnocked"))
        {
            animator.SetBool("isMoving", false);
            AttackPlayer();
        }
    }
    public void AttackPlayer()
    {
        if (!animator.GetBool("isKnocked"))
        {
            if (stopattack == 0)
            {
                attack = true;
                attacktiming = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (!animator.GetBool("isKnocked"))
        {
            if (collider.gameObject.tag == "Player")
            {
                PlayerHealth player = collider.GetComponent<PlayerHealth>();
                if (attack == true)
                    if (attackDelay <= 0)
                    {
                        player.TakeDamage(damage);
                        attackDelay = 2;
                    }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {if (collision.gameObject.tag == "Player")
        {
            FollowPlayer();
            move = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StopPlayer();
            move = false;
        }
    }
}
