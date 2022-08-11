using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] GameObject[] spots2;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshPro attemptsText;
    [SerializeField] private GameObject gameOver;
    public int scoreUpdate;
    public int attemptsUpdate = 10;
    public static bool gameEnded = false;
    // public int finalScore = 0;
    public AudioSource gameOverJingle;
    private int audioStop;
    public static bool killMusic = false;

    private void Awake()
    {
        killMusic = false;
        audioStop = 1;
    }

    void Update()
    {
        if (Spot.score != 0)
        {
            scoreUpdate = Spot.score;
            //Debug.Log(scoreUpdate);
            scoreText.text = "Score: " + scoreUpdate;
        }

        if (MathQuizScript.attempts != 10)
        {
            attemptsUpdate = MathQuizScript.attempts;
            attemptsText.text = "Attempts: " + attemptsUpdate + " / 10";

            if (attemptsUpdate == 0)
            {
                killMusic = true;
                gameOver.SetActive(true);
                gameEnded = true;

                if (audioStop == 1)
                {
                    GameOverJingle();
                    audioStop = 2;
                }

                for (int i = 0; i < 7; i++)
                {
                    spots2[i].SetActive(false);
                }
            }
        }
    }

    void GameOverJingle()
    {
        gameOverJingle.Play();
    }
}
