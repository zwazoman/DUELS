using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    private float _lifeTime = 5f;

    private void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(QueueTimer());
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

    //private void Start()
    //{
    //    ShootFromSky.ProjectilesPool.Enqueue(this.gameObject);
    //}

    private IEnumerator QueueTimer()
    {
        while (gameObject.transform.position.y >= 0)
        {
            yield return null;
        }
        gameObject.SetActive(false);
        ShootFromSky.ProjectilesPool.Enqueue(gameObject);
    }
}
