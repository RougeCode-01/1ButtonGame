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
        HealthManager.Instance.IncreaseHealth();
        Destroy(gameObject);
        Debug.Log("Heart Destroyed");
    }
}
