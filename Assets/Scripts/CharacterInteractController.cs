using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharaterController2D))]
public class CharacterInteractController : MonoBehaviour
{
    private CharaterController2D _charaterController2D;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;
    [SerializeReference] private HighlightController _highlightController;
    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _charaterController2D = GetComponent<CharaterController2D>();
    }
    
    private void Update()
    {
        Check();
        
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Check()
    {
        Vector2 position = _rigidbody2D.position + _charaterController2D.lastMotionVector * offsetDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (var collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                _highlightController.Highlight(interactable.gameObject);
                return;
            }
        }

        _highlightController.Hide();
    }

    private void Interact()
    {
        Vector2 position = _rigidbody2D.position + _charaterController2D.lastMotionVector * offsetDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (var collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(_character);
                break;
            }
        }
        
    }
}
