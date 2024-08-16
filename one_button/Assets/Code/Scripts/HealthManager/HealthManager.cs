using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : Singleton<HealthManager>
{
    public TextMeshProUGUI HealthText;
    public float Health = 3;

    public override void Awake()
    {
        Debug.Log("Awake");
        base.Awake();
    }
    void Start()
    {
        Debug.Log("Start");
        Health = 3;
    }
    private void OnEnable()
     {
         SceneManager.sceneLoaded += OnSceneLoaded;// Subscribe to the sceneLoaded event when the script is enabled
    }
     private void OnDisable()
     {
         SceneManager.sceneLoaded -= OnSceneLoaded;// Unsubscribe from the sceneLoaded event when the script is disabled
    }
      void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
     {
        Debug.Log("OnSceneLoaded");
        if (HealthText == null)
        {
            GameObject healthUI = GameObject.Find("Health");
            if (healthUI != null)
            {
                HealthText = healthUI.GetComponent<TextMeshProUGUI>();
                updateHealthUI();//// Update the health UI with the current health value
            }
        }
    }
    void updateHealthUI() 
    {
        HealthText.text = "Health:"+Health.ToString();
    }

    public void DecreaseHealth(int amount = 1)
    {// Decrease the player's health by 1
        Health -= amount;
        updateHealthUI();
    }
    public void IncreaseHealth(int add=1)
    { // Increase the player's health by 1
        Debug.Log("Health Increased");
        Health+= add;
        updateHealthUI();
    }
}
