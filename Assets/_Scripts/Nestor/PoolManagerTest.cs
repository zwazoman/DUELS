using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerTest : MonoBehaviour
{
    public Queue<GameObject> BulletsQueue { get; private set; }


    [SerializeField] int _poolSize;
    [SerializeField] GameObject _bulletPrefab;

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            BulletsQueue.Enqueue(bullet);
            bullet.SetActive(false);
        }
    }

    public void Summon(Vector3 position, Quaternion rotation, float scaleFactor, float speedFactor)
    {
        GameObject currentBullet = BulletsQueue.Dequeue();
        currentBullet.transform.position = position;
        currentBullet.transform.rotation = rotation;
        currentBullet.transform.localScale *= scaleFactor;
        currentBullet.GetComponent<StraightBullet>().SpeedMultiplier = speedFactor;
        currentBullet.SetActive(true);
    }

    public void Kill(GameObject con)
    {

    }
}
