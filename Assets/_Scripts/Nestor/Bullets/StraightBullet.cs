using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StraightBullet : MonoBehaviour
{
    public float SpeedMultiplier { get; set; }
    public float SizeMultiplier { get; set; }

    public GameObject Cannon { get;set; }


    [SerializeField] float _speed = 1;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.Rotate(Cannon.transform.rotation.eulerAngles);
        transform.localScale *= SizeMultiplier;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 0.1f * _speed * SpeedMultiplier);
    }
}
