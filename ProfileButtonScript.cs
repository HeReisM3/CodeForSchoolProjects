using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileButtonScript : MonoBehaviour
{
    public GameObject profileOwner;

    public void SetOwnerActive()
    {
        if (!profileOwner.activeInHierarchy)
            profileOwner.SetActive(true);
        else if (profileOwner.activeInHierarchy)
            profileOwner.SetActive(false);
    }
}
