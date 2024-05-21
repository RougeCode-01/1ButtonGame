using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour
{
    private Score_manager collectableCounter;
    private void Start()
    {
        collectableCounter = FindObjectOfType<Score_manager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision Picked Up");
            if (collectableCounter != null)
            {
                collectableCounter.CollectablePickedup();
                Destroy(gameObject);
            }
            
        } 
    }
    
    
}
