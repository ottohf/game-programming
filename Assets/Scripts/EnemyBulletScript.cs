using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;
    public float ttl;

    // Update is called once per frame
    void Update()
    {
        // Decrease ttl (time to live)
        ttl -= Time.deltaTime;

        // If ttl is greater than 0, continue moving the bullet
        if (ttl > 0)
        {
          
            // Move bullet forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            // Destroy the bullet after ttl reaches 0
            Destroy(gameObject);
        }
    }
}