using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteChangerScript : MonoBehaviour
{
    private Sprite sadGiraffe, happyGiraffe, sadMonkey, happyMonkey;
    private SpriteRenderer rend;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "Minus")
        {
            rend = GetComponent<SpriteRenderer>();
            sadGiraffe = Resources.Load<Sprite>("giraffe_nospots");
            happyGiraffe = Resources.Load<Sprite>("happy_giraffe");
            rend.sprite = sadGiraffe;
        }
        // if (sceneName == "Minus")
        // {
        //     rend = GetComponent<SpriteRenderer>();
        //     sadMonkey = Resources.Load<Sprite>("Apina");
        //     happyMonkey = Resources.Load<Sprite>("Apina");
        //     rend.sprite = sadMonkey;
        // }

    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "Minus")
        {

            if (StarsScript.giraffeIsHappy)
            {
                rend.sprite = happyGiraffe;
            }
        }
    }
}
