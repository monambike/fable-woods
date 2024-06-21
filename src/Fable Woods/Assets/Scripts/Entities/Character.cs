using UnityEngine;

public class Character : MonoBehaviour
{

    private Rigidbody rb;

    [Header("Movement")]

    public bool playerCanMove = true;

    public float walkSpeed = 5f;
    
    public float maxVelocityChange = 10f;

    public float rotationSpeed = 500f;

    private bool isWalking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (playerCanMove)
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            if (SettingsData.InvertAxisX) horizontalInput *= 1;

            var verticalInput = Input.GetAxis("Vertical");
            if (SettingsData.InvertAxisY) verticalInput *= -1;

            // Calculate how fast we should be moving
            Vector3 movementDirection = new(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();
            
            transform.Translate(movementDirection * walkSpeed * Time.deltaTime, Space.World);

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
