using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private Vector3 axis = new Vector3(0, 0, 1);
    [SerializeField] private string button;
    
    public GameObject targetToRotateAround;
    
    private void FixedUpdate()
    {
        if (Input.GetKey(button)) // Check if the button is held down
        {
            RotateToTheLeft();
        }
        else
        {
            RotateToTheRight();
        }
    }

    private void RotateToTheLeft()
    {
        transform.RotateAround(targetToRotateAround.transform.position, axis, speed * Time.deltaTime);
    }
    
    private void RotateToTheRight()
    {
        transform.RotateAround(targetToRotateAround.transform.position, -axis, speed * Time.deltaTime);
    }
}