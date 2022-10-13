using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiotestScript : MonoBehaviour
{
    [SerializeField] public AudioSource scorePlus;
    // Start is called before the first frame update


    void Update()
    {
        scorePlus.volume = VolumeScript.soundVolume;
        
        if (Spot.audioInvoke == 2)
        {
            ScoreUpSound();
        }
    }

    public void ScoreUpSound()
    {
        scorePlus.Play();
        Spot.audioInvoke = 1;
    }
}
