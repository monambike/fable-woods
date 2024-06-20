using UnityEngine;

public class Character : MonoBehaviour
{

    private Rigidbody rb;

    [Header("Movement")]

    public bool playerCanMove = true;

    public float walkSpeed = 5f;
    
    public float maxVelocityChange = 10f;

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
            var horizontalInput = -Input.GetAxis("Horizontal");
            if (SettingsData.InvertAxisX) horizontalInput *= 1;

            var verticalInput = -Input.GetAxis("Vertical");
            if (SettingsData.InvertAxisY) verticalInput *= -1;

            // Calculate how fast we should be moving
            Vector3 targetVelocity = new(horizontalInput, 0, verticalInput);

            targetVelocity = transform.TransformDirection(targetVelocity) * walkSpeed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = targetVelocity - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }
}
