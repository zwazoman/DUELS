using UnityEngine;
using UnityEngine.InputSystem;

public class MashPLayer1 : MonoBehaviour
{
    [SerializeField] private GameObject _player1;
    [SerializeField] private Vector3 _vector = new Vector3(0, 0.1f, 0);
    [SerializeField] private MashingGame _game;

    public void OnClimb1(InputAction.CallbackContext context)
    {
        if (_game.CanInteract == true)
        {
            if (context.performed == true)
            {
                _player1.transform.position += _vector;
            }
        }
    }
}
