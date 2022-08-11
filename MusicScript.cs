using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript: MonoBehaviour
{
    public AudioSource musicSource;
    public static float musicVolume = 0.010f;

    private void Update() 
    {
        musicSource.volume = musicVolume;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
