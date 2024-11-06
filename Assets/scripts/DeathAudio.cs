using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudio : MonoBehaviour
{
    public AudioClip soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    //this is called to play the sound effect one time 
    public void PlaySound()
    {
        audioSource.PlayOneShot(soundEffect);
    }
    //used in loadsceneafterdelay method in snakehead class
    public float GetClipLength()
    {
        return audioSource.clip != null ? audioSource.clip.length : 0f;
    }
}
