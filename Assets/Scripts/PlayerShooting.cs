using UnityEngine;
using UnityEngine.InputSystem; // For the new Input System

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab; // Assign your prefab in the inspector
    public Transform shootPoint; // Assign your shoot point in the inspector
    public int counter;

    private PlayerControls controls; // Reference to your PlayerControls class

    private void Awake()
    {
        controls = new PlayerControls(); // Initialize your PlayerControls
    }

    private void OnEnable()
    {
        controls.Enable(); // Enable the input controls
    }

    private void OnDisable()
    {
        controls.Disable(); // Disable the input controls to avoid conflicts
    }

    void Update()
    {
        // Check if the left mouse button is pressed
        if (controls.Player.Fire.triggered) // Assuming fire action is defined
        {
            counter++;
            // Instantiate the prefab at the shoot point
            GameObject clone = Instantiate(prefab, shootPoint.position, shootPoint.rotation);
            BulletScript bulletScript = clone.GetComponent<BulletScript>();
            if (bulletScript != null)
            {
                bulletScript.counter = counter;
            }
        }
    }
}