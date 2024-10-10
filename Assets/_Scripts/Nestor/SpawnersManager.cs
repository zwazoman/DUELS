using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    

    [Header("Cannons")]
    [SerializeField] Cannon _cannon1;
    [SerializeField] Cannon _cannon2;
    [SerializeField] Cannon _cannon3;
    [SerializeField] Cannon _cannon4;

    [Header("Bullets Prefabs")]
    [SerializeField] GameObject[] _bullets;

    [Header("Parameters")]
    [SerializeField] float _minSpeedFactor = 1;
    [SerializeField] float _maxSpeedFactor = 10;
    [SerializeField] float _minSizeFactor = 1;
    [SerializeField] float _maxSizeFactor = 10;
    [SerializeField] float _minSpawnRate = 3;
    [SerializeField] float _maxSpawnRate = 5;
    [SerializeField] float _difficultyIncreaseTime = 10;

    [Header("Sounds")]
    [SerializeField] AudioClip[] _shootSounds;
    [SerializeField] float _shootSoundsVolume = 1f;

    float _bulletsSpeedMultiplier = 1;
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
            IncreaseDifficulty();
        }
    }

    IEnumerator Spawn()
    {
        while (GameManager.Instance.GameIsPlaying)
        {
            GameObject choosenPrefab = _bullets[Random.Range(0, _bullets.Length)];
            float choosenSpeedFactor = Random.Range(_minSpeedFactor, _maxSpeedFactor) * _bulletsSpeedMultiplier;
            float choosenSizeFactor = Random.Range(_minSizeFactor, _maxSizeFactor);
            float topOrBot = Random.Range(0, 2);
            if(topOrBot == 0)
            {
                _cannon1.Shoot(choosenPrefab, choosenSpeedFactor, choosenSizeFactor);
                _cannon2.Shoot(choosenPrefab, choosenSpeedFactor, choosenSizeFactor);
            }
            else
            {
                _cannon3.Shoot(choosenPrefab, choosenSpeedFactor, choosenSizeFactor);
                _cannon4.Shoot(choosenPrefab, choosenSpeedFactor, choosenSizeFactor);
            }

            SFXManager.Instance.PlaySFXClip(_shootSounds, transform.position, _shootSoundsVolume);
            yield return new WaitForSeconds(Random.Range(_minSpawnRate, _maxSpawnRate) * _spawnRateMultiplier);
        }
        
    }

    void IncreaseDifficulty()
    {
        _bulletsSpeedMultiplier *= 1.1f;
        _spawnRateMultiplier *= 0.8f;
    }

    void StopShoot()
    {
        StopCoroutine(Spawn());
    }
}
