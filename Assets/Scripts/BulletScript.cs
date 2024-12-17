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
    public int counter; // Set from PlayerShooting

    public float normalOpacity = 1f; // The default opacity (1 = fully opaque)
    public float superBulletOpacity = 0.5f; // The opacity for super bullets

    // Start is called before the first frame update
    void Start()
    {
        currentScale = initialScale;

        // Find the Renderer component specifically on the "donut" grandchild object
        Renderer renderer = GetComponentInChildren<Renderer>();

        if (renderer != null && renderer.gameObject.name == "donut")
        {
            // Determine if this is a super bullet
            if (counter % 5 == 0)
            {
                scaleIncreaseRate *= 3;
                speed *= 3;
                print("super bullet fired");

                // Set the base map color to pure red for a super bullet
                renderer.material.SetColor("_BaseColor", new Color(1f, 0f, 0f, superBulletOpacity));
            }
            else
            {
                // Set the base map color to white for a normal bullet
                renderer.material.SetColor("_BaseColor", new Color(1f, 1f, 1f, normalOpacity));
            }
        }
        else
        {
            Debug.LogWarning("No 'donut' Renderer found on the bullet's grandchild.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
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
                // Destroy the bullet after ttl reaches 0
                Destroy(gameObject);
            }
        }
    }
}