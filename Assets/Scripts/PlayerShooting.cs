using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public Transform shootPoint;
    public int counter;
    public float fireRate = 0.5f;

    private PlayerControls controls;
    private float nextFireTime = 0f;

    private AudioSource audioSource;

    // Two sound effects
    public AudioClip soundEffect1;
    public AudioClip soundEffect2;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        // Check if Fire action is triggered and if enough time has passed since the last shot
        if (controls.Player.Fire.triggered && Time.time >= nextFireTime && Time.timeScale != 0)
        {
            nextFireTime = Time.time + fireRate; // Set the next allowed fire time
            counter++;

            // Instantiate the prefab at the shoot point
            GameObject clone = Instantiate(prefab, shootPoint.position, shootPoint.rotation);

            // Alternate sound effects based on counter
            if (counter % 5 == 0 && counter != 0)
            {
                audioSource.PlayOneShot(soundEffect2);
            }
            else
            {
                audioSource.PlayOneShot(soundEffect1);
            }

            // Pass counter to the bullet script
            BulletScript bulletScript = clone.GetComponent<BulletScript>();
            if (bulletScript != null)
            {
                bulletScript.counter = counter;
            }
        }
    }
}