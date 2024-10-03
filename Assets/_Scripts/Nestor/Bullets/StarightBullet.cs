using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarightBullet : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    [SerializeField] float _size;


    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(Vector3.left * _speed);
    }
}
