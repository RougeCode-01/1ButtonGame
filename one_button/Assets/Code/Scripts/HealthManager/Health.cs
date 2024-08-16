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
        Debug.Log("Heart dsadas");
        Destroy(gameObject);
        HealthManager.Instance.IncreaseHealth();
        Debug.Log("Heart Destroyed");

    }
}
