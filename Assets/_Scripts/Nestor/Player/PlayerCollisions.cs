using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    float _expulseForce = 20f;

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
        _rb.AddForce((Vector3.up - transform.right) * _expulseForce,ForceMode.Impulse);
        _rb.AddTorque(0,0,8,ForceMode.Impulse);
        _coll.enabled = false;
        _movement.enabled = false;

        Destroy(this);
        GameManager.Instance.PlayerDied();
    }
}
