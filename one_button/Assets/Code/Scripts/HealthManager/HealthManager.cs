using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : Singleton<HealthManager>
{
    //public static HealthManager instance;   
    public TextMeshProUGUI HealthText;
    private Enemy_movement Enemy;
    public float Health = 3;

    public override void Awake()
    {
        Debug.Log("Awake");
        base.Awake();
        /*if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
        
    }
    void Start()
    {
        Debug.Log("Start");
        Health = 3;
    }

     private void OnEnable()
     {
         SceneManager.sceneLoaded += OnSceneLoaded;
     }
     private void OnDisable()
     {
         SceneManager.sceneLoaded -= OnSceneLoaded;
     }
      void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
     {
        //updateHealthUI();
        Debug.Log("OnSceneLoaded");
     }

    private void Update()
    {
        //updateHealthUI();
        if (HealthText == null)
        {
            GameObject go = GameObject.Find("Health");
            if (go != null)
            {
                HealthText = go.GetComponent<TextMeshProUGUI>();
                updateHealthUI();
            }
        }
    }


    void updateHealthUI() 
    {
        HealthText.text = "Health:"+Health.ToString();
    }

    public void DecreaseHealth(int amount = 1)
    {
        Health -= amount;
        updateHealthUI();
    }
}
