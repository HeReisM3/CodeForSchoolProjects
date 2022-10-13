using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadScene()//new game, all random questions
    {
        MathQuizScript.attempts = 10;
        StarsScript.giraffeIsHappy = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void Restart()
    {
        MathQuizScript.attempts = 10;
        StarsScript.giraffeIsHappy = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RestartChallengeMode()
    {
        //MathQuizScript.attempts = 10;
        StarsScript.giraffeIsHappy = false;
        SceneManager.LoadScene("ChalllengeMode");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit application");
    }

    public void Plus()
    {
        MathQuizScript.attempts = 10;
        StarsScript.giraffeIsHappy = false;
        SceneManager.LoadScene("Plus");
    }

    public void Minus()
    {
        MathQuizScript.attempts = 10;
        StarsScript.giraffeIsHappy = false;
        SceneManager.LoadScene("Minus");
    }

    public void Multiplication()
    {
        MathQuizScript.attempts = 10;
        StarsScript.giraffeIsHappy = false;
        SceneManager.LoadScene("Multiplication");
    }

    public void Division()
    {
        MathQuizScript.attempts = 10;
        StarsScript.giraffeIsHappy = false;
        SceneManager.LoadScene("Division");
    }
}