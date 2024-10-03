using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullet : MonoBehaviour
{
    [SerializeField] float _bounceForce;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        _rb.AddForce(Vector3.down * _bounceForce, ForceMode.Impulse);
    }


}
