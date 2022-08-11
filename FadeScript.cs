using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    private float timer;
    private float timer2;
    private Animator anim;
    public GameObject hp;
    public GameObject lives;
    public GameObject keyUI;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 4.5f;
        timer2 = 3f;
    }

    // Update is called once per frame
    void Update()
    {

        if (ShipScript.readyForTakeoff)
        {
            timer -= Time.deltaTime;

            if (timer < 0.1f)
            {
                anim.SetTrigger("fade");
                hp.SetActive(false);
                lives.SetActive(false);
                keyUI.SetActive(false);

                if (!hp.activeInHierarchy)
                {
                    timer2 -= Time.deltaTime;

                    if (timer2 < 0.1f)
                        SceneManager.LoadScene("Congrats");
                }

            }
        }

    }
}