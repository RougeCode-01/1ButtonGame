using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform circleCenter;
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerDestroyed");
            Destroy(other.gameObject);
        }
    }
    private void Start()
    {
      Vector3 direction = ( transform.position - circleCenter.position ).normalized;
        transform.position = circleCenter.position + direction * radius;
    }
    private void Update()
    {
        RotateAroundCircle();
    }
    void RotateAroundCircle()
    {
      /*  Vector3 directionToPlayer = (Player.position - circleCenter.position).normalized;
        Vector3 desiredPosition = circleCenter.position + directionToPlayer * radius;
        Vector3 currentDirection = (transform.position - circleCenter.position).normalized;
        float angleDiffrence = Vector3.SignedAngle(currentDirection, desiredPosition, Vector3.forward);*/

        transform.RotateAround(circleCenter.position, Vector3.forward,  speed * Time.deltaTime);
    }
}
