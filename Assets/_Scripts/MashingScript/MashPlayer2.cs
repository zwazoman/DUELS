using UnityEngine;
using UnityEngine.InputSystem;

public class MashPlayer2 : MonoBehaviour
{
    [SerializeField] private GameObject _player2;
    [SerializeField] private Vector3 _vector = new Vector3(0, 0.1f, 0);
    [SerializeField] private MashingGame _game;

    public void OnClimb2(InputAction.CallbackContext context)
    {
        if (_game.CanInteract == true)
        {
            if (context.performed == true)
            {
                _player2.transform.position += _vector;
            }
        }
    }
}
