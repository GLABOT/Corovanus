using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public SoundsManager snd;

    public AudioSource arc;

    public AudioClip[] crystallSounds;

    private int randomSounds;

    public void PlayCrystallSounds()
    {
        randomSounds = Random.Range(0,crystallSounds.Length - 1);
        arc.PlayOneShot(crystallSounds[randomSounds]);
    }
}
