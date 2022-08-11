using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    private void Start() 
    {
        if (Time.timeScale == 0f)//tsekkaa onko peli jäänyt pauselle, jos on niin laittaa pausen pois
            Time.timeScale = 1f;
    }
    public void LoadScene()//new game
    {
        SceneManager.LoadScene("Level_Saija");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit application");
    }
}
