using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RespawnPlayer : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 enemyStartPosition;
    public GameObject player;
    public GameObject enemy;

    private void Awake()
    {
        player = GameObject.Find("Player(Dave)");
        //enemy = GameObject.FindWithTag("Enemy");
    }

    private void Start()
    {
        startPosition = player.transform.position;
        //enemyStartPosition = enemy.transform.position;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            player.transform.position = startPosition;
            Debug.Log("Respawned player");
        }
    }
    
    
}