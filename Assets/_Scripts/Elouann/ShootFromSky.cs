using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootFromSky : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    //[SerializeField]
    //private float _projectileFallSpeed;

    [SerializeField]
    private float _shootCooldown = 0.75f;
    private float _timer;

    private Camera _mainCamera;

    // Materials
    [Header("Cursor color change materials")]
    [SerializeField]
    private Material _cursorMaterial;
    [SerializeField]
    private Material _onClickMaterial;

    // Components
    private MeshRenderer _renderer;

    // Datas declarations
    private Vector3 _projectileSpawnPoint;
    private Ray _ray;
    private RaycastHit _hit;

    // Projectile pool
    public static Queue<GameObject> ProjectilesPool;
    private GameObject _currentProjectile;

    public void Shoot()
    {
        if (!Cooldown.GameStarted) return;
        StartCoroutine(ClickAnimation());
        if (_timer > 0) return;
        print("SHOOT");
        //Instantiate(_projectilePrefab, _projectileSpawnPoint, Quaternion.identity);
        _currentProjectile = ProjectilesPool.Dequeue();
        _currentProjectile.transform.position = _projectileSpawnPoint;
        _currentProjectile.SetActive(true);
        _timer = _shootCooldown;
    }

    private void Awake()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<MeshRenderer>();
        _timer = _shootCooldown;
    }

    private void Start()
    {
        for(int i = 15; i >= 0; i--)
        {
            GameObject go = Instantiate(_projectilePrefab, Vector3.zero, Quaternion.identity);
            //ProjectilesPool.Enqueue(go);
            print(i);
        }
    }

    private void Update()
    {
        _ray  = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hit)) 
        {
            transform.position = _hit.point;
        }
        _projectileSpawnPoint = new Vector3(this.transform.position.x, this.transform.position.y + 10, this.transform.position.z);
        _timer -= 0.01f;
    }

    private IEnumerator ClickAnimation()
    {
        _renderer.material = _onClickMaterial;
        yield return new WaitForSeconds(0.12f);
        _renderer.material = _cursorMaterial;
    }
}
