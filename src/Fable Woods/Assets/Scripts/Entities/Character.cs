using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{

    private Rigidbody rb;

    public CameraManager cameraManager;

    [Header("Audio")]

    public AudioSource footstepsSource;

    public AudioClip[] grassFootsteps;

    public float stepDelay = 0.5f;

    private float lastStepTime;

    [Header("Movement")]

    public bool playerCanMove = true;

    public float walkSpeed = 5f;
    
    public float maxVelocityChange = 10f;

    public float rotationSpeed = 500f;

    public FootstepsType footstepsType;

    [SerializeField]
    private bool isWalking = false;

    [SerializeField]
    private bool isSprinting = false;

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

    private void Update()
    {
        footstepsSource.enabled = isWalking;
        Footsteps();
    }

    private void OnChangeCamera(InputAction.CallbackContext callbackContext)
    {
        cameraManager.SwitchCamera(cameraManager.GetSwitchNextCamera());
    }

    private void Footsteps()
    {
        if (Time.time - lastStepTime >= stepDelay)
        {
            int index = Random.Range(0, grassFootsteps.Length);
            // Enable footsteps sound if player is walking.
            footstepsSource.enabled = isWalking;

            // If player is sprinting, make the footsteps sound faster.
            if (isSprinting) footstepsSource.pitch = 1.5f;
            // Otherwise, play footsteps sound at normal speed.
            else footstepsSource.pitch = 1.0f;

            footstepsSource.PlayOneShot(grassFootsteps[index]);
            lastStepTime = Time.time;
        }
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

            // Getting movement direction.
            Vector3 movement = new(horizontalInput, 0, verticalInput);
            movement.Normalize();
            // Moving character.
            rb.transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);

            // Updating variable flag for walking.
            isWalking = movement.x != 0 || movement.z != 0;

            // Updating character rotation according to movement.
            if (movement != Vector3.zero)
            {
                var toRotation = Quaternion.LookRotation(movement, Vector3.up);
                rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    public enum FootstepsType
    {
        Grass,
        Water
    }
}
