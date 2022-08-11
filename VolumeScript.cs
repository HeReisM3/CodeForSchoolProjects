using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript : MonoBehaviour
{
    public AudioSource hoverSoundSource;
    public AudioSource confirmSoundSource;
    public static float soundVolume = 0.015f;

    private void Update() 
    {
        hoverSoundSource.volume = soundVolume;
        confirmSoundSource.volume = soundVolume;
    }

    public void UpdateVolume(float volume)
    {
        soundVolume = volume;
    }
}
