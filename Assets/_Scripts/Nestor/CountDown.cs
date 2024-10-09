using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] float _timeToWait;
    [SerializeField] TMP_Text _text;
    [SerializeField] PlayerMovement _player1Movement;
    [SerializeField] PlayerMovement _player2Movement;

    private void Awake()
    {
        Cursor.visible = false;
    }

    IEnumerator Start()
    {
        Time.timeScale = 0;
        for(int i = 0; i < _timeToWait; i++)
        {
            _text.text = (_timeToWait - i).ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        Destroy(_text);
        _player1Movement.EnableMovement = true;
        _player2Movement.EnableMovement = true;
        Time.timeScale = 1;
    }

}
