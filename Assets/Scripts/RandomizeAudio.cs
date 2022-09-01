using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAudio : MonoBehaviour
{
    public AudioClip[] sound;
    public AudioSource audioSource;

    private void Start()
    {
        int rand = Random.Range(0, sound.Length);
        audioSource.clip = sound[rand];
        audioSource.Play();
    }
}
