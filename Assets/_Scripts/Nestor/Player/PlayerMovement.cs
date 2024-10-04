using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpForce = 5f;

    public bool IsGrounded = false;
    float _horizontal;
    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Physics.Raycast(transform.position, Vector3.down, 1.5f))
        //{
        //    IsGrounded = true;
        //}
        //else
        //{
        //    IsGrounded = false;
        //}
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_horizontal * _speed,_rb.velocity.y, _rb.velocity.z);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!IsGrounded) return;
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }    
    }
}
