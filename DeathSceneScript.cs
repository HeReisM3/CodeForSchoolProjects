using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level_Saija");
    }
    
    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
