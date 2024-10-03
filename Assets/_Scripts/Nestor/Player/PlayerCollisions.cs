using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //Die();
            Destroy(collision.gameObject);
        }
    }

    void Die()
    {
        //animation de merde
        Destroy(this);
        GameManager.Instance.PlayerDied();
    }
}
