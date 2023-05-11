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
        // Controleer of de AudioClip is ingesteld
        if (clip == null)
        {
            Debug.LogError("Audio clip is not set!");
            return;
        }

        // Configureer de AudioSource-component
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.volume = volume;

        // Start de audio indien loop niet aan staat
        if (!loop)
        {
            audioSource.Play();
        }
    }

    public void Play()
    {
        // Speel de audio af
        audioSource.Play();
    }

    public void Stop()
    {
        // Stop de audio
        audioSource.Stop();
    }

    public void SetVolume(float vol)
    {
        // Pas het volume aan
        volume = vol;
        audioSource.volume = volume;
    }

    public void SetLoop(bool l)
    {
        // Pas de loop-instellingen aan
        loop = l;
        audioSource.loop = loop;
    }

    public void ClipPlay(Vector3 playPosition)
    {
        // Speel de audio af op de opgegeven positie
        AudioSource.PlayClipAtPoint(clip, playPosition, volume);
    }
}
