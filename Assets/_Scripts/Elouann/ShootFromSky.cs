using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromSky : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

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
    [SerializeField] private List<GameObject> _projectilesToEnqueue;
    public static Queue<GameObject> ProjectilesPool = new Queue<GameObject>();
    private GameObject _currentProjectile;

    public void Shoot()
    {
        // si le jeu est fini
        if (!TrucsQuiTombentManager.Instance.GameRunning) return;
        StartCoroutine(ClickAnimation());
        if (_timer > 0) return;

        // setup projectile
        _currentProjectile = ProjectilesPool.Dequeue();
        _currentProjectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _currentProjectile.transform.position = _projectileSpawnPoint;
        Vector3 rot = new Vector3(Random.Range(10, -10), Random.Range(10, -10), 0);
        _currentProjectile.transform.rotation *= Quaternion.Euler(rot);
        
        // lancement projectile
        _currentProjectile.SetActive(true);
        
        // reset cooldown
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
        print("BEGINNING");
        foreach(GameObject go in _projectilesToEnqueue)
        {
            ProjectilesPool.Enqueue(go);
            print(go.name);
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
