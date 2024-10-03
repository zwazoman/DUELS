using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpForce = 5f;

    bool _isGrounded = false;
    float _horizontal;
    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.5f))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
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
            if (!_isGrounded) return;
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }    
    }
}
