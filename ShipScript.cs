using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject player;
    public static bool readyForTakeoff;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        readyForTakeoff = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        player.SetActive(false);
        readyForTakeoff = true;

    }
}
