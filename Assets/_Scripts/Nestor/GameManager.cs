using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{
    public event Action OnPlayerDied;

    public bool GameIsPlaying = true;

    [SerializeField] PlayerCollisions Player1Collisions;
    [SerializeField] PlayerCollisions Player2Collisions;

    [SerializeField] BlackTransition _transi;


    //Singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _transi.TransitionOut();
    }

    public void PlayerDied()
    {
        OnPlayerDied?.Invoke();
        if(Player1Collisions == null)
        {
            //player2 won
            Player2Collisions.enabled = false;
            GameIsPlaying = false;
            BackToMenu();
        }
        else
        {
            //player1 won
            Player1Collisions.enabled = false;
            GameIsPlaying = false;
            BackToMenu();
        }
    }

    void BackToMenu()
    {
        _transi.TransitionIn(() => SceneManager.LoadScene("Menu"));
        //yield return null;
    }
}
