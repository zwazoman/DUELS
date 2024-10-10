using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(QueueTimer());
        if (collider.tag == "Player")
        {
            TrucsQuiTombentManager.Instance.GameEnd();
        }
        if (collider.tag == "Untagged") return;
        gameObject.SetActive(false);
        ShootFromSky.ProjectilesPool.Enqueue(gameObject);
    }

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
