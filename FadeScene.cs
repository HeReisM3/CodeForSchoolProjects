using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    private float timer;


    void Start()
    {
        timer = 7.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0.1f)

        SceneManager.LoadScene("MainMenu");
    }
}
