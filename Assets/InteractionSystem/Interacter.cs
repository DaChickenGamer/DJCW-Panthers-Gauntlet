using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Interacter : MonoBehaviour
{
    private static Interacter instance;
    public static Interacter MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Interacter>();
            }
            return instance;
        }
    }
    [SerializeField] private Transform _interactionPoint; // Interaction Point
    [SerializeField] private float _interactionPointRadius = 0.5f; // The radius in which you can interact
    [SerializeField] private LayerMask _interactableMask;
    [HideInInspector] public bool inInteractionRadius = false;

    private readonly Collider2D[] _colliders = new Collider2D[3];
    [SerializeField] private int _numFound; // Number of colliders found
    private bool _interacting = false; // Makes interacting into a bool
    private bool _isInteracting = false; // Prevents being away from a object and still doing the input

    private void Update()
    {
        _numFound = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>(); // Gets the interface
            inInteractionRadius = true;

            if (interactable != null && _interacting == true) // New input system get key down || Implement Other Devices Later
            {
                interactable.Interact(this);
                _interacting = false;

                
            }
        }
        else if(_numFound <= 0 )
        {
            inInteractionRadius = false;
        }
    }
    public void OnInteract(InputAction.CallbackContext ctxt)
    {
        if (_isInteracting == true)
        {
            _interacting = false;
            _isInteracting = false;
        }
        else if (_isInteracting == false)
        {
            _interacting = true;
            _isInteracting = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
