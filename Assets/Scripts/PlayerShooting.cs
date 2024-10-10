using UnityEngine;
using UnityEngine.InputSystem; // For the new Input System
// Add your namespace here if needed
// using YourNamespace; 

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab; // Assign your prefab in the inspector
    public Transform shootPoint; // Assign your shoot point in the inspector

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
            // Instantiate the prefab at the shoot point
            GameObject clone = Instantiate(prefab, shootPoint.position, shootPoint.rotation);
        }
    }
}