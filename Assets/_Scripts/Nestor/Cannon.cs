using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Transform _shootSocket;

    public void Shoot(GameObject bulletPrefab, float bulletSpeedFactor, float bulletSizeFactor)
    {
        GameObject bullet = Instantiate(bulletPrefab, _shootSocket.position, Quaternion.identity);
        StraightBullet bulletScript = bullet.GetComponent<StraightBullet>();
        bulletScript.SpeedMultiplier = bulletSpeedFactor;
        bulletScript.SizeMultiplier = bulletSizeFactor;
    }
}
