using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public bool loop = false;

    void Start()
    {

        audioSource.clip = clip;
        audioSource.loop = loop;

        // Het starten van de audio
        audioSource.Play();
    }


    public void OneShot()
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
    public void ClipPlay(Vector3 playPosition)
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}
