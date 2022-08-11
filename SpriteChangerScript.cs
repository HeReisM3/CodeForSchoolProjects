using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangerScript : MonoBehaviour
{
    private Sprite sadGiraffe, happyGiraffe;
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        sadGiraffe = Resources.Load<Sprite>("giraffe_nospots");
        happyGiraffe = Resources.Load<Sprite>("happy_giraffe");
        rend.sprite = sadGiraffe;
    }

    // Update is called once per frame
    void Update()
    {
        if (StarsScript.giraffeIsHappy)
        {
            rend.sprite = happyGiraffe;
        }
    }
}
