using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveProto : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;
    private Rigidbody _rb;

    private void Awake()
    {
        this._rb = this.GetComponent<Rigidbody>();
        this._playerInput = this.GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if (!Cooldown.GameStarted) return;
        var dir = this._playerInput.actions.FindAction("Move").ReadValue<Vector2>();
        this._rb.velocity = new Vector3(dir.x, 0, dir.y) * this._speed;
        if (dir != Vector2.zero)
        {
            this._rb.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));
        }
    }

    private void Update()
    {
        // merci Nathan le boss
        Vector3 direction = Matrix4x4.Rotate(Quaternion.Euler(Vector3.up * 0)) * new Vector3(this._playerInput.actions.FindAction("Move").ReadValue<Vector2>().x, 0, this._playerInput.actions.FindAction("Move").ReadValue<Vector2>().y);
        if (direction.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.up *(Mathf.Atan2(-direction.z, direction.x) * Mathf.Rad2Deg + 90f)), Time.deltaTime * _rotationSpeed); // rotaton jolie
        }
    }
}

