using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;
    [SerializeField] private AudioSource shootSound;

    //Pelaajassa kiinni oleva koodi, hiiren vasenta näppäintä painamalla ammuttaessa kutsutaan Shoot-funktiota, joka luo Prefabin, jossa on taas oma koodinsa kiinni.
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootSound.volume = VolumeScript.soundVolume;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (PauseMenuScript.gameIsPaused != true)
        {
            shootSound.Play();
            Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
