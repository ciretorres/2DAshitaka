using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    private Animator animator;

    [SerializeField] private float _moveSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed,
            _joystick.Vertical * _moveSpeed, _rigidbody.velocity.y);

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _animator.SetFloat("moveX", _joystick.Horizontal);
            _animator.SetFloat("moveY", _joystick.Vertical);
            //_animator.SetBool("moving", true);
            animator.SetBool("moving", true);
        } else
        {
            //_animator.SetBool("moving", false);
            animator.SetBool("moving", false);
        }
    }
}
