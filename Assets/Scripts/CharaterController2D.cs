using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharaterController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    [SerializeField] private float speed = 2f;
    private Vector2 motionVector;
    public Vector2 lastMotionVector;
    public bool moving;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(horizontal, vertical);
        
        _animator.SetFloat("horizontal", horizontal);
        _animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        _animator.SetBool("moving", moving);

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            _animator.SetFloat("lastHorizontal", lastMotionVector.x);
            _animator.SetFloat("lastVertical", lastMotionVector.y);
        }
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