using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line

public class GameManager : MonoBehaviour
{
    [SerializeField] private int totalCollectibles; 
    [SerializeField] private int currentLevel = 1; // Set this to the current level number
    [SerializeField] private int loadDelay;
    private int _collectedCollectibles = 0;
    private bool levelcompletesfx = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all collectibles have been collected
        if (_collectedCollectibles >= totalCollectibles)
        {
            StartCoroutine(LoadNextLevelAfterDelay(loadDelay));
        }
    }

    IEnumerator LoadNextLevelAfterDelay(float delay)
    {
        if (levelcompletesfx == false)
        {
            AudioManager.Instance.PlayLevelCompleteSound();
            levelcompletesfx = true;
        }
        yield return new WaitForSeconds(delay);

        // Check if the next scene exists
        if (currentLevel + 1 < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene based on the current level number
            SceneManager.LoadScene(currentLevel + 1);
            levelcompletesfx = false;
        }
        else
        {
            // If there is no next scene, restart the game or load a specific scene
            SceneManager.LoadScene(0); // Load the first scene
        }
    }

    // Call this method when a collectible is collected
    public void CollectibleCollected()
    {
        _collectedCollectibles++;
    }
}