using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Die();
        }
    }

    void Die()
    {
        //animation de merde
        Destroy(this);
        GameManager.Instance.PlayerDied();
    }
}
