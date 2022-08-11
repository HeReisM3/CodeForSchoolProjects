using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;

    void Start()
    {
        
    }


    void Update()//asetetaan uusi enemy aktiiviseksi kun edellinen enemy-objekti tuhoutuu
    {
        if (!enemy && enemy1)
            enemy1.SetActive(true);

        if (!enemy && !enemy1 && enemy2)
            enemy2.SetActive(true);
        
        if (!enemy && !enemy1 && !enemy2 && enemy3)
            enemy3.SetActive(true);
        
        if (!enemy && !enemy1 && !enemy2 && !enemy3 && enemy4)
            enemy4.SetActive(true);
        
        if (!enemy && !enemy1 && !enemy2 && !enemy3 && !enemy4 && enemy5)
            enemy5.SetActive(true);
        
        if (!enemy && !enemy1 && !enemy2 && !enemy3 && !enemy4 && !enemy5 && enemy6)
            enemy6.SetActive(true);
    }
}
