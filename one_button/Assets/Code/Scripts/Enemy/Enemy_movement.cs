using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
     public Transform Player;
     public  Transform circleCenter;
     public float radius;
     public float speed;



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
        transform.RotateAround(circleCenter.position, Vector3.forward, speed * Time.deltaTime);
    }
    
    
    

    
}