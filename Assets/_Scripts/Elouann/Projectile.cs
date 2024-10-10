using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] AudioClip[] _playerDeathSounds;
    [SerializeField] float _playerDeathVolume;

    private void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(QueueTimer());
        if (collider.tag == "Player")
        {
            //SFXManager.Instance.PlaySFXClip(_playerDeathSounds, transform.position, 1);
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
