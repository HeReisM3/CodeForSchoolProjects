using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfileScript : MonoBehaviour
{
    [SerializeField] private GameObject[] plusStars;
    [SerializeField] private GameObject[] minusStars;
    [SerializeField] private GameObject[] divisionStars;
    [SerializeField] private GameObject[] multiplyStars;
    public GameObject congratsBG;
    public GameObject profileOwner;

    // Start is called before the first frame update
    void Start()
    {
        if (StarsScript.oldPlusScore >= 8 && StarsScript.oldPlusScore <= 10)
        {
            plusStars[0].SetActive(true);
        }
        else if (StarsScript.oldPlusScore <= 14 && StarsScript.oldPlusScore > 10)
        {
            plusStars[1].SetActive(true);
        }
        else if (StarsScript.oldPlusScore > 14)
        {
            plusStars[2].SetActive(true);
        }

        if (StarsScript.oldMinusScore >= 8 && StarsScript.oldMinusScore <= 10)
        {
            minusStars[0].SetActive(true);
        }
        else if (StarsScript.oldMinusScore <= 14 && StarsScript.oldMinusScore > 10)
        {
            minusStars[1].SetActive(true);
        }
        else if (StarsScript.oldMinusScore > 14)
        {
            minusStars[2].SetActive(true);
        }

        if (StarsScript.oldDivScore >= 8 && StarsScript.oldDivScore <= 10)
        {
            divisionStars[0].SetActive(true);
        }
        else if (StarsScript.oldDivScore <= 14 && StarsScript.oldDivScore > 10)
        {
            divisionStars[1].SetActive(true);
        }
        else if (StarsScript.oldDivScore > 14)
        {
            divisionStars[2].SetActive(true);
        }

        if (StarsScript.oldMulScore >= 8 && StarsScript.oldMulScore <= 10)
        {
            multiplyStars[0].SetActive(true);
        }
        else if (StarsScript.oldMulScore <= 14 && StarsScript.oldMulScore > 10)
        {
            multiplyStars[1].SetActive(true);
        }
        else if (StarsScript.oldMulScore > 14)
        {
            multiplyStars[2].SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "MainMenu")
        {
            if (congratsBG.activeInHierarchy)
            {
                UpdateStars();
            }
        }
    }

    void UpdateStars()
    {
        if (StarsScript.oldPlusScore >= 8 && StarsScript.oldPlusScore <= 10)
        {
            plusStars[0].SetActive(true);
        }
        else if (StarsScript.oldPlusScore <= 14 && StarsScript.oldPlusScore > 10)
        {
            plusStars[1].SetActive(true);
        }
        else if (StarsScript.oldPlusScore > 14)
        {
            plusStars[2].SetActive(true);
        }

        if (StarsScript.oldMinusScore >= 8 && StarsScript.oldMinusScore <= 10)
        {
            minusStars[0].SetActive(true);
        }
        else if (StarsScript.oldMinusScore <= 14 && StarsScript.oldMinusScore > 10)
        {
            minusStars[1].SetActive(true);
        }
        else if (StarsScript.oldMinusScore > 14)
        {
            minusStars[2].SetActive(true);
        }

        if (StarsScript.oldDivScore >= 8 && StarsScript.oldDivScore <= 10)
        {
            divisionStars[0].SetActive(true);
        }
        else if (StarsScript.oldDivScore <= 14 && StarsScript.oldDivScore > 10)
        {
            divisionStars[1].SetActive(true);
        }
        else if (StarsScript.oldDivScore > 14)
        {
            divisionStars[2].SetActive(true);
        }

        if (StarsScript.oldMulScore >= 8 && StarsScript.oldMulScore <= 10)
        {
            multiplyStars[0].SetActive(true);
        }
        else if (StarsScript.oldMulScore <= 14 && StarsScript.oldMulScore > 10)
        {
            multiplyStars[1].SetActive(true);
        }
        else if (StarsScript.oldMulScore > 14)
        {
            multiplyStars[2].SetActive(true);
        }
    }

    public void ResetProgress()
    {
        StarsScript.oldPlusScore = 0;
        StarsScript.oldMinusScore = 0;
        StarsScript.oldDivScore = 0;
        StarsScript.oldMulScore = 0;

        for (int x = 0; x <= 2; x++)
        {
            if (plusStars[x].activeInHierarchy)
                plusStars[x].SetActive(false);
            if (minusStars[x].activeInHierarchy)
                minusStars[x].SetActive(false);
            if (multiplyStars[x].activeInHierarchy)
                multiplyStars[x].SetActive(false);
            if (divisionStars[x].activeInHierarchy)
                divisionStars[x].SetActive(false);
        }
    }
}
