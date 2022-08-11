using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

//Pelaajassa kiinni oleva kerättävän metallin koodi. Objekti tuhotaan siihen törmätessä ja counter nousee aina yhdellä.
public class CollectMetalScript : MonoBehaviour
{
    public GameObject animationActive;
    public GameObject metalUIpicture;
    public GameObject keyPicture;
    public GameObject metalTextUI;
    private int metal = 0;
    [SerializeField] private TextMeshProUGUI metalText;
    private float timer = 0.25f;
    private bool activated = false;
    [SerializeField] private AudioSource collectMetal;
    [SerializeField] private AudioSource gotKey;
    public static bool enoughMetal;

    private void Start() 
    {
        enoughMetal = false;
    }

    private void Update() 
    {

        collectMetal.volume = VolumeScript.soundVolume;
        gotKey.volume = VolumeScript.soundVolume;

        if (!ConsoleScript.printingKey)
        {
        
            if (activated)
            {
                animationActive.SetActive(true);
                timer -= Time.deltaTime;
            }

            if (timer < 0.05f)
            {
                activated = false;
                animationActive.SetActive(false);
            }

            if (!activated)
            {
                timer = 0.25f;
            }

            if (metal >= 10)
            {
                enoughMetal = true;
            }
        }
        else if (ConsoleScript.printingKey && !keyPicture.activeInHierarchy)
        {
            metalUIpicture.SetActive(false);
            keyPicture.SetActive(true);
            metalTextUI.SetActive(false);
            gotKey.Play();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Metal"))
        {
            collectMetal.Play();
            Destroy(collision.gameObject);
            metal++;
            activated = true;
            metalText.text = "x " + metal;
        }
    }
}
