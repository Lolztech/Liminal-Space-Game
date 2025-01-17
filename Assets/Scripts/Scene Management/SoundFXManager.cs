using System.Xml.Serialization;
using UnityEngine;

// This script is used to play sound effects in the game
// From https://www.youtube.com/watch?v=DU7cgVsU2rM

public class SoundFXManager : MonoBehaviour
{
    // Singleton pattern
    // Should only be one instance of this class
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // Spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioClip.length;
        Destroy(audioSource.gameObject, clipLength);

    }

    public void PlayRandomSoundFXClip(AudioClip[] audioClips, Transform spawnTransform, float volume)
    {
        // Select a random clip from the array
        int rand = Random.Range(0, audioClips.Length);
        AudioClip selectedClip = audioClips[rand]; 

        // Spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = selectedClip; 
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = selectedClip.length;
        Destroy(audioSource.gameObject, clipLength);
    }


}

// Example usage
// Play single sound
// SoundFXManager.instance.PlaySoundFXClip(mySoundClip, Position, 0.5f);
// Play random sound
// SoundFXManager.instance.PlayRandomSoundFXClip(mySoundClips, Position, 0.5f);
