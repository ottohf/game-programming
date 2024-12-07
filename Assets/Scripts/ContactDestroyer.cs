using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("PlayerBase"))
        {
            var life = other.gameObject.GetComponent<Life>();
            if (life != null)
            {
                life.amount -= 1;
            }
            else
            {
                Debug.LogError("hit object has no life" + other);
            }
        }
        if (gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}