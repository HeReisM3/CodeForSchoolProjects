using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleScript : MonoBehaviour
{

    public static bool talkingToConsole;
    public GameObject consoleUI;
    public GameObject baseScreen;
    public GameObject failScreen;
    private bool failScreenActive;
    public static bool printingKey;


    private void Start() 
    {
        printingKey = false;
        talkingToConsole = false;
        failScreenActive = false;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            talkingToConsole = false;
            consoleUI.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            if (CollectMetalScript.enoughMetal)
            {
                printingKey = true;
                talkingToConsole = false;
                baseScreen.SetActive(true)
;               consoleUI.SetActive(false);
                //konsoli sulkeutuu ja metalliscriptiin tieto..
            }
            else if (!CollectMetalScript.enoughMetal)
            {
                failScreen.SetActive(true);
                failScreenActive = true;
                baseScreen.SetActive(false);
            }
        }
        
        if (failScreenActive && Input.GetKey(KeyCode.Return))
        {
            talkingToConsole = false;
            failScreen.SetActive(false);
            baseScreen.SetActive(true)
;           consoleUI.SetActive(false);
            failScreenActive = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        talkingToConsole = true;
        consoleUI.SetActive(true);
        //ConsoleUI.SetActive(true);

    }

}
