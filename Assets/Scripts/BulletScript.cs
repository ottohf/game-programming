using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float ttl;
    public float initialScale;
    public float scaleIncreaseRate;

    private float currentScale;

    // Start is called before the first frame update
    void Start()
    {
        currentScale = initialScale;
    }

    // Update is called once per frame
    void Update()
    {        
        // Decrease ttl (time to live)
        ttl -= Time.deltaTime;

        // If ttl is greater than 0, continue moving and growing the bullet
        if (ttl > 0)
        {
           
          
            // Slowly increase bullet size
            currentScale += scaleIncreaseRate * Time.deltaTime;
            transform.localScale = new Vector3(currentScale, currentScale, currentScale);

            // Move bullet forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        else
        {
            // Destroy the bullet after 10 seconds (ttl reaches 0)
            Destroy(gameObject);
        }
    }
}