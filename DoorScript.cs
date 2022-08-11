using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool touchDoor;
    public GameObject locked;
    public GameObject askforKey;
    public GameObject usedKey;
    private bool usedTheKey;
    private float activeTime;
    private float activeTime2;
    public GameObject metalDoor;
    public GameObject doorWay;
    public GameObject doorCollider;
    
    [SerializeField] private AudioSource success;
    


    // Start is called before the first frame update
    void Start()
    {
        activeTime = 1.5f;
        activeTime2 = 1.5f;
        touchDoor = false;
        usedTheKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        success.volume = VolumeScript.soundVolume;

        if (touchDoor && !ConsoleScript.printingKey)
        {
            activeTime -= Time.deltaTime;
        
            if ( activeTime < 0 )
            {
                locked.SetActive(false);
                activeTime = 1.5f;
                touchDoor = false;
            }
        }

        if (askforKey.activeInHierarchy && touchDoor && ConsoleScript.printingKey && Input.GetKey(KeyCode.Y))
        {
            askforKey.SetActive(false);
            OpenDoor();
        }
        else if (touchDoor && ConsoleScript.printingKey && Input.GetKey(KeyCode.N))
        {
            askforKey.SetActive(false);
        }

        if (usedTheKey)
        {
            metalDoor.SetActive(false);
            doorWay.SetActive(true);
            doorCollider.SetActive(false);

            activeTime2 -= Time.deltaTime;

            if (activeTime2 < 0)
            {
                usedKey.SetActive(false);
                activeTime2 = 1.5f;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (!ConsoleScript.printingKey)
        {
            Locked();
        }
        else if (ConsoleScript.printingKey && usedTheKey == false)
        {
            UsingKey();
        }
    }

    private void Locked()
    {
        locked.SetActive(true);
        touchDoor = true;
    }

    private void UsingKey()
    {
        touchDoor = true;
        askforKey.SetActive(true);

    }

    private void OpenDoor()
    {
        usedKey.SetActive(true);
        usedTheKey = true;
        success.Play();

    }
}
