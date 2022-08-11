using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public GameObject activateObject;
    private Animator anim;
    public float timer = 5;
    private bool wasHit = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (wasHit)
        {
            anim.SetBool("wasHit", true);
            activateObject.SetActive(true);
            timer -= Time.deltaTime;

        }

        if (timer < 0.5)
        {
            wasHit = false;
            activateObject.SetActive(false);
            anim.SetBool("wasHit", false);
        }

        if (wasHit == false)
        {
            timer = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            anim.SetBool("wasHit", true);
            wasHit = true;
        }
    }
}
