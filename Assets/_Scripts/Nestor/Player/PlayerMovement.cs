using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    static float _speed = 8f;
    static float _jumpForce = 10f;

    [Header("Sounds")]
    [SerializeField] AudioClip[] _jumpSounds;
    [SerializeField] float _jumpSoundsVolume = 1f;

    public bool IsGrounded = false;
    public bool EnableMovement = false;
    float _horizontal;
    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_horizontal * _speed,_rb.velocity.y, _rb.velocity.z);
        //_rb.AddForce(Vector3.right * _horizontal * _speed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!EnableMovement) return;
        _horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && EnableMovement)
        {
            if (!IsGrounded) return;
            SFXManager.Instance.PlaySFXClip(_jumpSounds, transform.position, _jumpSoundsVolume);
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }    
    }
}
