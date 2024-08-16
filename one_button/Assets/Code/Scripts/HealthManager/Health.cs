using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, Icollectable
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
    public  void Collect()
    {
        Destroy(gameObject);// Destroys the Collectable 
        HealthManager.Instance.IncreaseHealth();// Increase the player's health
        Debug.Log("Heart Destroyed");
    }
}


