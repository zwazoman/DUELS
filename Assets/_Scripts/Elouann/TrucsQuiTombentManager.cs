using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrucsQuiTombentManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public bool GameRunning { get; set; }

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
        
    }

    public void GameEnd()
    {
        GameRunning = false;
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
