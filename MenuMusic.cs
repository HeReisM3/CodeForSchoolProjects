using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        menuMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
