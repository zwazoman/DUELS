using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            TrucsQuiTombentManager.Instance.GameEnd();
            //TrucsQuiTombentManager.Instance.GameRunning = false;
        }
        if (collider.tag == "Untagged") return;
        gameObject.SetActive(false);
        ShootFromSky.ProjectilesPool.Enqueue(gameObject);
    }

    private void Start()
    {
        ShootFromSky.ProjectilesPool.Enqueue(this.gameObject);
    }
}
