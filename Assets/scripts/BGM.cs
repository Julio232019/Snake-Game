using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    /*tried to make this class handle the BGM, but the program kept breaking so 
    decided to just make it inside my snakehead class, but my snakehead script
    still asks for a bgm object,not really sure why lol so now this is just here,
    i can probably remove this script completely but im scared to so i am keeping
    it in just in case*/
    public AudioClip soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    public void PlaySound()
    {
        audioSource.Play();
    }

    

} 