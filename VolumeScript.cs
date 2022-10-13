using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScript: MonoBehaviour
{
    public AudioSource soundSource;
    public static float soundVolume = 1f;

    private void Update() 
    {
        soundSource.volume = soundVolume;
    }

    public void updateVolume(float volume)
    {
        soundVolume = volume;
    }
}