using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharaterController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    [SerializeField] private float speed = 2f;
    private Vector2 motionVector;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _animator.SetFloat("horizontal", motionVector.x);
        _animator.SetFloat("vertical", motionVector.y);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = motionVector * speed;
    }
}
