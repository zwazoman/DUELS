using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarightBullet : MonoBehaviour
{
    public float _speedMultiplier { get; set; }


    [SerializeField] float _speed = 1;
    [SerializeField] float _sizeMultiplier = 1;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        transform.localScale *= _sizeMultiplier;
    }

    private void Start()
    {
        transform.Rotate(0,-90,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //_rb.AddForce(Vector3.left * _speed);
        transform.Translate(Vector3.forward * 0.1f * _speed);
    }
}
