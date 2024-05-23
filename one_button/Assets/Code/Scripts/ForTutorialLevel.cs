using UnityEngine;
using UnityEngine.SceneManagement;

public class ForTutorialLevel : MonoBehaviour
{
    [SerializeField] private float sceneDelay;
    private GameObject _tutorialTextOne;
    private GameObject _tutorialTextTwo;
    private bool _jumpButtonPressed;

    private void Start()
    {
        _tutorialTextOne = GameObject.Find("TutorialText1");

        // This will find all GameObjects in the scene, including inactive ones
        foreach (GameObject go in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (!go.CompareTag("TutorialText")) continue;
            _tutorialTextTwo = go;
            break;
        }

        _jumpButtonPressed = false; // Initialize the flag to false
    }

    private void Update()
    {
        // If the Jump button is not pressed or has been pressed before, exit the function early
        if (!Input.GetButton("Jump") || _jumpButtonPressed) return;

        // If the Jump button is pressed for the first time, deactivate the first text and activate the second one
        _tutorialTextOne.SetActive(false);
        _tutorialTextTwo.SetActive(true);

        _jumpButtonPressed = true; // Set the flag to true after the Jump button has been pressed

        // Load the next scene after a few seconds
        Invoke("LoadNextScene", sceneDelay);
    }

    private void LoadNextScene()
    {
        // Load the next scene.
        SceneManager.LoadScene("TutorialTwo");
    }
}