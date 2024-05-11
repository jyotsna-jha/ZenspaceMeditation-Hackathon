using UnityEngine;

public class Scene1AudioController : MonoBehaviour
{
    public AudioSource musicAudioSource; // Reference to the AudioSource component in the inspector

    void Start()
    {
        // Ensure musicAudioSource is assigned in the inspector
        if (musicAudioSource == null)
        {
            Debug.LogError("Music AudioSource not assigned!");
            return;
        }

        // Play the audio clip and set it to loop
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
}