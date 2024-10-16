using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCharacter : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Vector2 movementInput; // Store movement input
    private Vector2 lookInput; // Store look input

    private Rigidbody rb; // For applying forces on player

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddRelativeForce(
            movementInput.x * Time.deltaTime*speed*1000,
            0,
            movementInput.y * Time.deltaTime * speed*1000);
        rb.AddRelativeTorque(0, lookInput.x * rotationSpeed * Time.deltaTime, 0);
    }

    // Input methods for the new Input System using CallbackContext
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}