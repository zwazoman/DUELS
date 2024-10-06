using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] Transform _camera;

    float _expulseForce = 22f;

    PlayerMovement _movement;
    Collider _coll;
    Rigidbody _rb;


    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody>();
        _coll = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _movement.IsGrounded = true;
        }
        if (collision.gameObject.layer == 6)
        {
            Die();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _movement.IsGrounded = false;
        }
    }

    void Die()
    {
        Vector3 cameraDirection = (_camera.position + Vector3.up * 6) - _rb.position;
        _rb.freezeRotation = false;
        _rb.AddForce((/*Vector3.up - transform.forward*/cameraDirection.normalized) * _expulseForce,ForceMode.Impulse);
        _rb.AddTorque(0,1,5,ForceMode.Impulse);
        _coll.enabled = false;
        _movement.enabled = false;

        Destroy(this);
        GameManager.Instance.PlayerDied();
    }
}
