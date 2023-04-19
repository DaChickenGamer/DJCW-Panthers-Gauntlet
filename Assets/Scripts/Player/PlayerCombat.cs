using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private bool _currentlyAttacking = false; // If the player is attackign or not
    private float _attackDuration = .4f; // How long an attack takes

    private static Animator animator;
    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnPunch(InputValue value)
    {
        if (_currentlyAttacking == false && animator.GetBool("isKicking") == false) // Checks if not attacking and another animation isn't playing
        {
            _currentlyAttacking = true;
            animator.SetBool("isPunching", true);
            Debug.Log("Punched");
            StartCoroutine(EndAttackAnimation("isPunching"));
        }

    }
    private void OnKick(InputValue value)
    {
        if (_currentlyAttacking == false && animator.GetBool("isPunching") == false) // Checks if not attacking and another animation isn't playing
        {
            _currentlyAttacking = true;
            animator.SetBool("isKicking", true);
            Debug.Log("Kicked");
            StartCoroutine(EndAttackAnimation("isKicking"));
        }
    }

    private void OnGrapple(InputValue value)
    {
        if(_currentlyAttacking == false && animator.GetBool("isPunching") == false && animator.GetBool("isKicking") == false)
        {
            _currentlyAttacking = true;
            // _currentlyAttacking.SetBool("isGrappling", true); // <--- Need grappling Animations
            Debug.Log("Grappled");
            StartCoroutine(EndAttackAnimation("isGrappling"));
        }
    }
    private IEnumerator EndAttackAnimation(string animBoolName)
    {
        yield return new WaitForSeconds(_attackDuration);
        animator.SetBool(animBoolName, false);
        _currentlyAttacking = false;
    }

}
