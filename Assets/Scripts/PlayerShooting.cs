using Unity.VisualScripting;
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

    private AudioSource blow;

    private void Awake()
    {
        controls = new PlayerControls();
    }


    private void Start()
    {
        blow = GetComponent<AudioSource>();
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
            blow.PlayOneShot(blow.clip);
            BulletScript bulletScript = clone.GetComponent<BulletScript>();
            if (bulletScript != null)
            {
                bulletScript.counter = counter;
            }
        }
    }
}