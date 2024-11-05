using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingAudio : MonoBehaviour
{
    public AudioClip soundEffect;
    private AudioSource audioSource;

    public float soundVolume = 0.5f;

    void Start()
    {
         audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect; 
        audioSource.volume = soundVolume; // Set volume so its not as loud and annoying
    }

    //this is used to play the sound each time it is called, along with setting the volume of the sound effect
    public void PlaySound()
    {
        audioSource.PlayOneShot(soundEffect,soundVolume);
    }

}
