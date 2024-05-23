using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //This is very similar to BR audio management
    private AudioClip coinSound;
    private AudioClip jumpSound;
    private AudioClip landSound;
    private AudioClip levelCompleteSound;

    //Singleton pattern for easy access
    public static AudioManager Instance { get; private set; }

    private AudioSource audioSource;

    private void Awake()
    {
        //Donotdestroy + load if there's no instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        // If no AudioSource component is found, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayLandSound()
    {
        audioSource.PlayOneShot(landSound);
    }

    public void PlayLevelCompleteSound()
    {
        audioSource.PlayOneShot(levelCompleteSound);
    }
}
