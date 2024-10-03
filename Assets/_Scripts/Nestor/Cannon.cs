using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Transform _shootSocket;

    public void Shoot(GameObject bulletPrefab, float bulletSpeed, float bulletSize)
    {
        GameObject bullet = Instantiate(bulletPrefab, _shootSocket.position, Quaternion.identity);
        StarightBullet bulletScript = bullet.GetComponent<StarightBullet>();
        // changer sa stat de speed 
        // changer sa stat de size
    }
}
