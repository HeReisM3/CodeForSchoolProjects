using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffAnim : MonoBehaviour
{
    public GameObject fader;
    private Animator anim;
    private float timer;
    public static bool fade;

    void Start()
    {
        fade = false;
        anim = GetComponent<Animator>();
        timer = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (ShipScript.readyForTakeoff)
        {
            timer -= Time.deltaTime;

            if (timer < 0.1f)
            {
                anim.SetTrigger("takeoff");
                fade = true;
                fader.SetActive(true);
            }
        }
    }
}
