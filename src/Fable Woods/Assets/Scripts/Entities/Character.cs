using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{

    private Rigidbody rb;

    public CameraManager cameraManager;

    [Header("Movement")]

    public bool playerCanMove = true;

    public float walkSpeed = 5f;
    
    public float maxVelocityChange = 10f;

    public float rotationSpeed = 500f;

    private bool isWalking = false;

    private InputAction _moveAction;

    public DefaultPlayerActions defaultPlayerActions;

    private void Awake()
    {
        defaultPlayerActions = new DefaultPlayerActions();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnChangeCamera(InputAction.CallbackContext callbackContext)
    {
        cameraManager.SwitchCamera(cameraManager.GetSwitchNextCamera());
    }

    private void OnEnable()
    {
        // Character movement.
        _moveAction = defaultPlayerActions.Player.Move;
        _moveAction.Enable();

        defaultPlayerActions.Player.ChangeCamera.performed += OnChangeCamera;
        defaultPlayerActions.Player.ChangeCamera.Enable();
    }

    private void OnDisable()
    {
        // Character movement.
        _moveAction.Disable();

        defaultPlayerActions.Player.ChangeCamera.performed -= OnChangeCamera;
        defaultPlayerActions.Player.ChangeCamera.Disable();
    }

    private void FixedUpdate()
    {
        var movementDirection = _moveAction.ReadValue<Vector2>();

        if (playerCanMove)
        {
            var horizontalInput = movementDirection.x;
            if (SettingsData.InvertAxisX) horizontalInput *= 1;

            var verticalInput = movementDirection.y;
            if (SettingsData.InvertAxisY) verticalInput *= -1;

            // Getting moviment direction.
            Vector3 movement = new(horizontalInput, 0, verticalInput);
            movement.Normalize();
            // Moving character.
            rb.transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);

            // Updating character rotation according to movement.
            if (movement != Vector3.zero)
            {
                var toRotation = Quaternion.LookRotation(movement, Vector3.up);
                rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
