using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    

    [Header("Cannons")]
    [SerializeField] Cannon _canon1;
    [SerializeField] Cannon _canon2;

    [Header("Bullets Prefabs")]
    [SerializeField] GameObject[] _bullets;

    [Header("Parameters")]
    [SerializeField] float _minSpeed = 1;
    [SerializeField] float _maxSpeed = 10;
    [SerializeField] float _minSize = 1;
    [SerializeField] float _maxSize = 10;
    [SerializeField] float _minSpawnRate = 3;
    [SerializeField] float _maxSpawnRate = 5;
    [SerializeField] float _difficultyIncreaseTime = 10;

    float _bulletsSpeedMultiplier = 1;
    float _bulletsSizeMultiplier = 1;
    float _spawnRateMultiplier = 1;

    float _timer = 0;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        GameManager.Instance.OnPlayerDied += StopShoot;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += 1 * Time.deltaTime;
        if(_timer >= _difficultyIncreaseTime)
        {
            _timer = 0;
            //IncreaseDifficulty();
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject choosenPrefab = _bullets[Random.Range(0, _bullets.Length - 1)];
            float choosenSpeed = Random.Range(_minSpeed, _maxSpeed) * _bulletsSpeedMultiplier;
            float choosenSize = Random.Range(_minSize, _maxSize) * _bulletsSizeMultiplier;
            _canon1.Shoot(choosenPrefab, choosenSpeed, choosenSize);
            yield return new WaitForSeconds(Random.Range(_minSpawnRate, _maxSpawnRate) * _spawnRateMultiplier);
        }
        
    }

    void IncreaseDifficulty()
    {
        _bulletsSpeedMultiplier *= 1.1f;
        _bulletsSizeMultiplier *= 1.1f;
        _spawnRateMultiplier *= 0.9f;
    }

    void StopShoot()
    {
        StopCoroutine(Spawn());
    }
}
