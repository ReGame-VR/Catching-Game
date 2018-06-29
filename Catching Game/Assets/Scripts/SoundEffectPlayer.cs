using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour {

    // The sound effects. Pick randomly from these arrays
    public AudioSource[] spawnSounds;
    public AudioSource[] successSounds;
    public AudioSource[] failSounds;

    // Play a random bounce sound from the array
    public void PlaySpawnSound()
    {
        AudioSource sound = spawnSounds[Random.Range(0, spawnSounds.Length)];
        sound.PlayOneShot(sound.clip);
    }

    // Play a random bounce sound from the array
    public void PlaySuccessSound()
    {
        AudioSource sound = successSounds[Random.Range(0, successSounds.Length)];
        sound.PlayOneShot(sound.clip);
    }

    // Play a random bounce sound from the array
    public void PlayFailSound()
    {
        AudioSource sound = failSounds[Random.Range(0, failSounds.Length)];
        sound.PlayOneShot(sound.clip);
    }
}
