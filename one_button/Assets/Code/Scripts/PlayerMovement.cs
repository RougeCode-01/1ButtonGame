using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private Vector3 axis = new Vector3(0, 0, 1);
    [SerializeField] private string button;
    
    public GameObject targetToRotateAround;//where the player pivots from 
    
    private void FixedUpdate()
    {
        if (Input.GetKey(button)) // Check if the button is held down
        {
            //RotateToTheLeft(); not needed anymore
            //Jump to the next target
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

    private void Jump()
    {
        // implement the jump mechanics
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Find a way to change to another circle and attach itself to it use targetToRotateAround to assign the circle
    }
}