using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
     public Transform Player;
     public  Transform circleCenter;
     public float radius;
     public float speed;

    [SerializeField] private float delay = 1f;
    private bool respawn;

    private RespawnPlayer respawnPlayer;
    
    private void Start()
    {
        respawnPlayer = FindObjectOfType<RespawnPlayer>();
        Vector3 direction = (transform.position - circleCenter.position).normalized;
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

        transform.RotateAround(circleCenter.position, Vector3.forward, speed * Time.deltaTime);
    }
    
    
    

    
}