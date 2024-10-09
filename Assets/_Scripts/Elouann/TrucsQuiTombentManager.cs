using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrucsQuiTombentManager : MonoBehaviour
{
    // UI
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _endPanel;

    [SerializeField] private Color _player1Color;
    [SerializeField] private Color _player2Color;
    // System
    public bool GameRunning { get; set; }

    private TextMeshProUGUI _playerP;
    private TextMeshProUGUI _hasWon;
    private Color _textColor;

    // Singleton
    #region Singleton

    private static TrucsQuiTombentManager _instance;

    public static TrucsQuiTombentManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("TrucsQuiTombentManager is null");
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            Debug.Log($"<color=#e655c4>{this.name}</color> instance <color=#eb624d>destroyed</color>");
        }
        else
        {
            _instance = this;
            Debug.Log($"<color=#e655c4>{this.name}</color> instance <color=#58ed7d>created</color>");
        }
    }
    #endregion

    private void Start()
    {
        _endPanel.SetActive(false);
        _textColor = Color.white;
        _playerP = _endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void GameEnd()
    {
        GameRunning = false;
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _endPanel.SetActive(true);
        UpdateEndText();
    }

    private void UpdateEndText()
    {
        _playerP.text = (GameTimer.GetTimer() <= 0) ? "Player 1 " : "Player 2 ";
        Color color = (GameTimer.GetTimer() <= 0) ? _player1Color : _player2Color;
        _playerP.color = color;
        //_hasWon.color = color;
        //_hasWon.text = (GameTimer.GetTimer() <= 0) ? "has won !";
    }
}
