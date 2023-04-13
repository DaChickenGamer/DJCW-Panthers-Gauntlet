using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{

    [SerializeField]private Animator _animator;

    const string BG = "Highlight-Glow";
    string _currentState;
    public void ButtonGlow()
    {
        ChangeAnimationState(BG);
    }

    private void ChangeAnimationState(string newState)
    {
        if (newState == _currentState)
        {
            return;
        }

        _animator.Play(newState);
        _currentState = newState;
    }
    
}
