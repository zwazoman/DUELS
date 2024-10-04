using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action OnPlayerDied;

    [SerializeField] PlayerCollisions Player1Collisions;
    [SerializeField] PlayerCollisions Player2Collisions;


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

    public void PlayerDied()
    {
        OnPlayerDied?.Invoke();
        if(Player1Collisions == null)
        {
            //player2 won
            Player2Collisions.enabled = false;
            BackToMenu();
        }
        else
        {
            //player1 won
            Player1Collisions.enabled = false;
            BackToMenu();
        }
    }

    void BackToMenu()
    {
        //load le menu
    }
}
