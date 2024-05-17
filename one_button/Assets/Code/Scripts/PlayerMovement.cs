using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private Vector3 axis = new Vector3(0, 0, 1);
    [SerializeField] private string button;
    private Rigidbody2D _rigidbody2D;
    private Transform _currentTarget; // Store the current target (collider)

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(button))
        {
            Jump();
        }
        else
        {
            RotateToTheRight();
        }
    }

    private void RotateToTheRight()
    {
        if (_currentTarget != null)
        {
            // Rotate around the current target
            transform.RotateAround(_currentTarget.position, -axis, speed * Time.deltaTime);
        }
    }
    private void RotateToTheLeft()
    {
        if (_currentTarget != null)
        {
            // Rotate around the current target
            transform.RotateAround(_currentTarget.position, axis, speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (_currentTarget != null)
        {
            // Calculate the direction from the player to the target
            Vector2 directionToTarget = (_currentTarget.position - transform.position).normalized;

            // Detach from the current target
            _currentTarget = null;

            // Apply a force in the opposite direction
            _rigidbody2D.AddForce(-directionToTarget * jumpForce, ForceMode2D.Impulse);

            Debug.Log("Jumping");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            _currentTarget = other.transform; // Set the current target
            Debug.Log("Attached to circle");
        }
    }
}