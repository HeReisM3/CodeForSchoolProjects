using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressIconLoader : MonoBehaviour
{
    public GameObject confirmLoad;
    
    public void ProgressLvlLoad()
    {
        if  (!confirmLoad.activeInHierarchy)
            confirmLoad.SetActive(true);
    }

    public void DeclineLoad()
    {
        if (confirmLoad.activeInHierarchy)
            confirmLoad.SetActive(false);
    }
}
