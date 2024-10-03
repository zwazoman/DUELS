using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Transform _shootSocket;

    public void Shoot(GameObject bulletPrefab, float bulletSpeed, float bulletSize)
    {
        GameObject bullet = Instantiate(bulletPrefab, _shootSocket.position, Quaternion.identity);
        // choper le script sur la balle
        // changer sa stat de speed 
        // changer sa stat de size
    }
}
