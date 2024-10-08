using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Transform _shootSocket;
    [SerializeField] GameObject _barrel;
    [SerializeField] float _barrelTorqueForce = 1f;
    [SerializeField] CinemachineImpulseSource _impulseSource;

    public void Shoot(GameObject bulletPrefab, float bulletSpeedFactor, float bulletSizeFactor)
    {
        GameObject bullet = Instantiate(bulletPrefab, _shootSocket.position, Quaternion.identity);
        StraightBullet bulletScript = bullet.GetComponent<StraightBullet>();
        bulletScript.SpeedMultiplier = bulletSpeedFactor;
        bulletScript.SizeMultiplier = bulletSizeFactor;
        bulletScript.Cannon = gameObject;
        if (_impulseSource != null ) _impulseSource.GenerateImpulse();
        //_barrel.GetComponent<Rigidbody>().AddTorque(-Vector3.forward,ForceMode.Impulse); claqué
    }
}
