using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveDoor : MonoBehaviour
{
    public GameObject leaveDoor;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        leaveDoor.SetActive(false);
    }
}
