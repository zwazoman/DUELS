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

    [SerializeField] GameObject _sceneChangerGiantButton;

    private GameTimer _gameTimer;
    private BlackTransition _transitionScript;

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
        _sceneChangerGiantButton.SetActive(false);
        _gameTimer = GameObject.Find("Cooldown").GetComponent<GameTimer>(); //
        _endPanel.SetActive(false);
        _textColor = Color.white;
        _playerP = _endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _transitionScript = GameObject.Find("Transition").GetComponent<BlackTransition>();
        _transitionScript.TransitionOut();
    }

    public void GameEnd()
    {
        GameRunning = false;
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _endPanel.SetActive(true);
        UpdateEndText();
        _sceneChangerGiantButton.SetActive(true);
    }

    private void UpdateEndText()
    {
        _playerP.text = (_gameTimer.GetTimer() <= 0) ? "Player 1 " : "Player 2 ";
        Color color = (_gameTimer.GetTimer() <= 0) ? _player1Color : _player2Color;
        _playerP.color = color;
    }
}
