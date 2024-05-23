using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Serialized fields are visible in the Unity editor
    [SerializeField] private float speed; // Speed of rotation
    [SerializeField] private float jumpForce; // Force applied when jumping
    [SerializeField] private Vector3 axis; // Axis of rotation
    [SerializeField] private string button; // Button to trigger actions
    [SerializeField] private float holdTime = 0.5f; // Time to wait for determining if the button was pressed or held

    private float timer; // Timer to track button hold time
    private bool isJumping; // Flag to check if the player is jumping
    private Rigidbody2D _rigidbody2D; // Reference to the Rigidbody2D component
    private Transform _currentTarget; // Store the current target (collider)

    private void Awake()
    {
        // Get the Rigidbody2D component
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Handle user input
        HandleInput();
        // Stick to the target
        StickToTarget();
    }

    private void HandleInput()
    {
        // Check for button press and release
        if (Input.GetButtonDown(button))
        {
            StartPress();
        }
        else if (Input.GetButtonUp(button))
        {
            EndPress();
        }

        // Rotate the player based on button hold time
        if (!isJumping && Input.GetButton(button) && Time.time > timer)
        {
            RotateToTheLeft();
        }
        else
        {
            RotateToTheRight();
        }
    }

    private void StickToTarget()
    {
        // If there's a current target, apply a force towards it
        if (_currentTarget != null)
        {
            Vector2 directionToTarget = (_currentTarget.position - transform.position).normalized;
            _rigidbody2D.AddForce(directionToTarget * speed, ForceMode2D.Force);
        }
    }

    private void StartPress()
    {
        // Reset jumping flag and start timer
        isJumping = false;
        timer = Time.time + holdTime;
    }

    private void EndPress()
    {
        // Check if button was held or pressed and perform action accordingly
        if (Time.time < timer)
        {
            Jump();
            AudioManager.Instance.PlayJumpSound();
        }
        isJumping = true;
    }

    private void RotateToTheRight()
    {
        // Rotate the player to the right
        Rotate(-axis);
    }

    private void RotateToTheLeft()
    {
        // Rotate the player to the left
        Rotate(axis);
    }

    private void Rotate(Vector3 rotationAxis)
    {
        // Rotate the player around the current target
        if (_currentTarget != null)
        {
            transform.RotateAround(_currentTarget.position, rotationAxis, speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        // Make the player jump away from the current target
        if (_currentTarget != null)
        {
            Vector2 directionToTarget = (_currentTarget.position - transform.position).normalized;
            _currentTarget = null;
            _rigidbody2D.AddForce(-directionToTarget * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jumping");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player collided with a circle and set it as the current target
        if (other.gameObject.CompareTag("Circle"))
        {
            _currentTarget = other.transform;
            Debug.Log("Attached to circle");
            AudioManager.Instance.PlayLandSound();
        }
    }
}
