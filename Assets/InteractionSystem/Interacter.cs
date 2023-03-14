using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Interacter : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint; // Interaction Point
    [SerializeField] private float _interactionPointRadius = 0.5f; // The radius in which you can interact
    [SerializeField] private LayerMask _interactableMask; 

    private readonly Collider2D[] _colliders = new Collider2D[3];
    [SerializeField] private int _numFound; // Number of colliders found

    private void Update()
    {
        _numFound = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>(); // Gets the interface

            if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame) // New input system get key down || Implement Other Devices Later
            {
                interactable.Interact(this);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
