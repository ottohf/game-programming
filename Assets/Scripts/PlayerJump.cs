using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool onGround;

    private Rigidbody rb;
    //private PlayerInput playerInput;
    private PlayerControls controls; // Reference to your PlayerControls class


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();

        // Register the jump action
        controls.Player.Jump.performed += OnJump;
    }

    //private void OnEnable()
    //{
    //    playerInput.Enable();
    //}

    //private void OnDisable()
    //{
    //    playerInput.Disable();
    //}

    private void Update()
    {
        onGround = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}