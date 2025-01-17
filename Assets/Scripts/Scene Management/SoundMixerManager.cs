using UnityEngine;
using UnityEngine.Audio;

// Used code from https://www.youtube.com/watch?v=DU7cgVsU2rM

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private  AudioMixer audioMixer;

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(volume) * 20f);
    }

    public void SetSoundFXVolume(float volume)
    {
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(volume) * 20f);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20f);
    }


}
