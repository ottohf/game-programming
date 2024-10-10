using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCharacter : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Vector2 movementInput; // Store movement input
    private Vector2 lookInput; // Store look input

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self);

        float rotationAmount = lookInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
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