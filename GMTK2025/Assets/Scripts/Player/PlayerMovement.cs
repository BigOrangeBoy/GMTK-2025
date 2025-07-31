using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Essential Objects and variables")]
    [SerializeField] private CharacterController charController;
    [SerializeField] private float movementSpeed = 12f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject plrCam;

    private FPPLookBehaviour mouseBehaviour;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isMoving = false;
    private bool isRunning = false;

    [Header("Essential Bools")]
    public bool isFroze = false;
    public bool moveAllowed = false;

    private void Awake()
    {
        mouseBehaviour = plrCam.GetComponent<FPPLookBehaviour>();
        mouseBehaviour.SetCursorState(true);
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        HandleMovement();

        velocity.y += gravity * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);

        UpdateMovementState();
    }

    private void HandleMovement()
    {
        float x = 0, z = 0;
        if (!isFroze)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        Vector3 move = transform.right * x + transform.forward * z;
        charController.Move(move * movementSpeed * Time.deltaTime);

        HandleRunning();
    }

    private void UpdateMovementState()
    {
        //Animation Handling for run and walk
    }

    private void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
            movementSpeed += 10;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isRunning)
        {
            isRunning = false;
            movementSpeed -= 10;
        }
    }
}
