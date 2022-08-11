using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour
{
    [SerializeField] private GameObject restart, toMenu;
    [SerializeField] private GameObject congratsBG, balloons;
    [SerializeField] private GameObject star1, star2, star3;
    private int attemptsAtEnd = 10;
    private int finalScore;
    private int currentScore;
    public static bool giraffeIsHappy = false;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource victory;
    private int stopAudio = 1;


    // Start is called before the first frame update
    void Awake()
    {
        giraffeIsHappy = false;
        stopAudio = 1;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreScript.killMusic)
        {
            music.Stop();
        }

        if (MathQuizScript.attempts != 10)
        {
            attemptsAtEnd = MathQuizScript.attempts;
            //Debug.Log(attemptsAtEnd);
        }
        
        if (Spot.score != 0)
        {
            currentScore = Spot.score;
        }


        if ( currentScore == 7)
        {
            finalScore = 7 + attemptsAtEnd;
            music.Stop();
            //Debug.Log(finalScore);

            if (finalScore != 0)
            {
                congratsBG.SetActive(true);
                restart.SetActive(true);
                toMenu.SetActive(true);
                giraffeIsHappy = true;
                balloons.SetActive(true);

                if (stopAudio == 1)
                {
                    PlayJingle();
                    stopAudio = 2;
                }

                if (finalScore > 14)
                {
                    star3.SetActive(true);
                }
                else if (finalScore <= 14 && finalScore > 10)
                {
                    star2.SetActive(true);
                }
                else if (finalScore <= 10)
                {
                    star1.SetActive(true);
                }
            }
        }
    }

    void PlayJingle()
    {
        victory.Play();
    }
}
