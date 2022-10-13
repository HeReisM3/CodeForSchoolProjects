using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Experimental.GlobalIllumination;

public class Spot : MonoBehaviour
{
    public GameObject[] spots;
    public GameObject[] panelSpots; //panelit sisällä pitävät spotit arrayssa, jotta saadaan oikeet kuvat päälle ja pois päältä
    public GameObject[] panelList; // Panelit laitettu listaan, että saa suljettua kaikki jos yrittää avata uutta
    public GameObject panel;
    public Transform spotStart;
    public Transform spotOnGiraffe;
    public bool isOnGiraffe;
    public static int score;//scorescripti käyttää tätä scoren updateen
    public static int audioInvoke;
    private static int o;

    private void Awake()
    {
        audioInvoke = 1;
        score = 0;
        o = 0;
    }

    void Start()
    {
        isOnGiraffe = false;
    }
    void Update()
    {
        if (isOnGiraffe == true)
        {
            panel.gameObject.SetActive(false);
            //gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-210, 100), Random.Range(-10, -150), 0);
        }

    }
    public void OpenAndCloseMath()
    {
        if (isOnGiraffe == false)
        {

            if (panel.gameObject.activeInHierarchy == true)
            {
                panel.gameObject.SetActive(false);
            }
            else
            {
                for (int i = 0; i < 7; i++) // Sulkee ensin kaikki panelit
                {
                    panelList[i].SetActive(false);
                }

                panel.gameObject.SetActive(true);
            }
        }
    }
    public void CorrectAnswer()
    {
        //gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(Random.Range(-210, 100), Random.Range(-10, -150), 0);
        gameObject.SetActive(false);//kirahvin ulkopuolella oleva spot menee pois päältä

        for (int n = 0; n < 7; n++)
            {
                for (o = 0; o < 7; o++) 
                {
                    if (!panelSpots[o].activeInHierarchy)
                    {
                        spots[o].SetActive(true);
                        audioInvoke = 2;
                    }
                }
            }

        score = score + 1;
    }

}
