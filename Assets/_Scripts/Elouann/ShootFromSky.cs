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

    // Datas
    private Vector3 _projectileSpawnPoint;

    public void Shoot()
    {
        StartCoroutine(ClickAnimation());
        if (_timer > 0) return;
        Instantiate(_projectilePrefab, _projectileSpawnPoint, Quaternion.identity);
        _timer = _shootCooldown;
    }

    private void Awake()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<MeshRenderer>();
        _timer = _shootCooldown;
    }

    private void Update()
    {
        Ray ray  = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit)) 
        {
            transform.position = raycastHit.point;
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
