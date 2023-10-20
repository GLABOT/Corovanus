using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance = null;

    public Sound[] sounds;

    [SerializeField] private AudioMixerGroup mainMixer;
    [SerializeField] private AudioMixerGroup effectsMixer;

    [SerializeField] private string mainTheme;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();

            if (sound.name == mainTheme)
                sound.audioSource.outputAudioMixerGroup = mainMixer;
            else
                sound.audioSource.outputAudioMixerGroup = effectsMixer;

            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }

    private void Start() => PlaySound(mainTheme, true);

    public void PlaySound(string name, bool turnOn)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogError(name + " not found.");
            return;
        }

        if (turnOn)
            s.audioSource.Play();
        else
            s.audioSource.Stop();
    }
}
