using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleBeepBoop : MonoBehaviour
{
    public GameObject beepBoop;
    public float activeTime;
    private bool activated = false;
    public GameObject bzzz;
    void Update()
    {
        if (activated == true)
        {
            activeTime -= Time.deltaTime;
        
            if ( activeTime < 0 )
            {
                beepBoop.SetActive(false);
                activeTime = 1.5f;
                activated = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            BeepBoop();
        }
    }

    private void BeepBoop()
    {
        beepBoop.SetActive(true);
        activated = true;

    }
}
