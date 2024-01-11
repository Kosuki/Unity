using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AmbianceAudioSource;
    public AudioSource ShotAudioSource;
    public AudioSource MusicAudioSource;
    public AudioSource PlushAudioSource;
    public AudioSource EventAudioSource;


    public void ShotSound()
    {
        ShotAudioSource.Play();
    }

    public void MusicSound()
    {
        MusicAudioSource.Play();
    }

    public void PlushSound()
    {
        PlushAudioSource.Play();
    }

    public void EventSound()
    {
        EventAudioSource.Play();
    }
}
