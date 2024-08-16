using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour,Icollectable
{
    private Score_manager collectableCounter;
    private GameManager gameManager; // Reference to the GameManager
    private void Start()
    {
        collectableCounter = FindObjectOfType<Score_manager>();
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager in the scene
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayCoinSound();
            Debug.Log("Collision Picked Up");
            if (collectableCounter != null)
            {
                Collect();
            }
            
        } 
    }
    public void Collect()
    {
        collectableCounter.CollectablePickedup();
        gameManager.CollectibleCollected();
        Destroy(gameObject);
    }
}
