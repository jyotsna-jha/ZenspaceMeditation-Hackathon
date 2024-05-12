using UnityEngine;
using UnityEngine.SceneManagement;

public class StopAudioAndChangeScene : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private bool audioEnded = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void Update()
    {
        // Check if the audio has ended
        if (!audioSource.isPlaying && !audioEnded)
        {
            audioEnded = true;
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        // Change the scene here
        SceneManager.LoadScene("home-screen");
    }
}