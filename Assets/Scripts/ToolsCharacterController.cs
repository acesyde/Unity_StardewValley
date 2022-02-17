using System;
using UnityEngine;

[RequireComponent(typeof(CharaterController2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ToolsCharacterController : MonoBehaviour
{
    private CharaterController2D _charaterController2D;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float offsetDistance = 1f;
    [SerializeField] private float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        _charaterController2D = GetComponent<CharaterController2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = _rigidbody2D.position + _charaterController2D.lastMotionVector * offsetDistance;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (var collider in colliders)
        {
            ToolHit hit = collider.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
        
    }
}
