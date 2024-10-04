using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : MonoBehaviour
{
    public float SpeedMultiplier { get; set; }
    public float SizeMultiplier { get; set; }


    [SerializeField] float _speed = 1;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.Rotate(0,-90,0);
        transform.localScale *= SizeMultiplier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 0.1f * _speed * SpeedMultiplier);
    }
}
