using UnityEngine;

public class MashingGame : MonoBehaviour
{
    [SerializeField] private GameObject _winPlayer1;
    [SerializeField] private GameObject _winPlayer2;
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    [field: SerializeField] public bool CanInteract { get; private set; }

    private void Start()
    {
        CanInteract = true;
    }

    private void FixedUpdate()
    {
        if (_player1.transform.position.y >= 2)
        {
            _winPlayer1.SetActive(true);
            CanInteract = false;
        }
        if (_player2.transform.position.y >= 2)
        {
            _winPlayer2.SetActive(true);
            CanInteract = false;
        }
    }
}
