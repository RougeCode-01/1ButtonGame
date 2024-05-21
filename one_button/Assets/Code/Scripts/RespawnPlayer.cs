using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private Vector3 _startPosition;//Use to set the player start position
    private GameObject player;//Refrence of the player

    private void Awake()
    {
        player = GameObject.Find("Player(Dave)");//Find the player gameobject 
    }

    private void Start()
    {
        _startPosition = player.transform.position; //set the start position to the players initial position
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            player.transform.position = _startPosition;//Set the players position back to the initial position
            Debug.Log("Respawned player");
        }
    }
}