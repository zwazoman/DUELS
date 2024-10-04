using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    float _expulseForce = 10f;

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
        _rb.AddForce((Vector3.up) * _expulseForce,ForceMode.Impulse);
        _coll.enabled = false;

        Destroy(this);
        GameManager.Instance.PlayerDied();
    }
}
