using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Search.Providers;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MathQuizScript : MonoBehaviour
{
    public GameObject tryAgain; //"woops! try again" -text object
    public float timer = 2f; //timer for when tryAgain text disappears
    public TextMeshProUGUI firstNumber;
    public TextMeshProUGUI secondNumber;
    //public TextMeshProUGUI scoreAmount;
    public TextMeshProUGUI sign;
    public TMP_InputField answer;
    public Button button;
    public Button spotButton;
    public GameObject panel;

    public int firstNumberInt;
    public int secondNumberInt;
    public int answerInt;
    public int quizType;
    bool wrongAnswer = false; //assisting bool value for timer, for tryAgain text
    public static int attempts = 10;//assisti attemptsiin
    

    private void Awake() 
    {
    }
    
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "SampleScene")
            RandomNumbers();
        else if (sceneName == "Plus")
            Plus();
        else if (sceneName == "Minus")
            Minus();
        else if (sceneName == "Multiplication")
            Multiplication();
        else if (sceneName == "Division")
            Division();
        
        //score = 0;

        //button.onClick.AddListener(RandomNumbers);
    }
    void Update()
    {
        if (wrongAnswer)//try again text stays for ~2 seconds, then turns off
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0.1f)
        {
            wrongAnswer = false;
            tryAgain.SetActive(false);
            timer = 2f;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            button.onClick.Invoke();
        }
    }

    public void RandomNumbers()
    {
        quizType = Random.Range(0, 4);

        switch (quizType)
        {
            case 0:
                Plus();
                break;
            case 1:
                Minus();
                break;
            case 2:
                Multiplication();
                break;
            case 3:
                Division();
                break;
        }
    }

    void Plus()
    {
        sign.text = "+";

        firstNumberInt = Random.Range(1, 10);

        secondNumberInt = Random.Range(1, 10);

        firstNumber.SetText(firstNumberInt.ToString());

        secondNumber.SetText(secondNumberInt.ToString());

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(PlusCheck);
    }
    void PlusCheck()
    {
        answerInt = int.Parse(answer.text);

        if (answerInt == firstNumberInt + secondNumberInt)
        {
            GetComponentInParent<Spot>().isOnGiraffe = true;
            GetComponentInParent<Spot>().CorrectAnswer();
            //Debug.Log("Oikein");
        }

        else
        {
            answer.text = "";
            if (attempts > 1)
            {
                tryAgain.SetActive(true);
            }

            wrongAnswer = true;
            attempts = attempts - 1;
            //score = 0;
            //Debug.Log("Väärin");
        }


        //UpdateScore();

        //button.onClick.RemoveAllListeners();
        //RandomNumbers();
    }
    void Minus()
    {
        sign.text = "-";

        firstNumberInt = Random.Range(1, 10);

        secondNumberInt = Random.Range(1, firstNumberInt);

        firstNumber.SetText(firstNumberInt.ToString());

        secondNumber.SetText(secondNumberInt.ToString());

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(MinusCheck);
    }
    void MinusCheck()
    {
        answerInt = int.Parse(answer.text);

        if (answerInt == firstNumberInt - secondNumberInt)
        {
            //score++;
            //Debug.Log("Oikein");
            GetComponentInParent<Spot>().isOnGiraffe = true;
            GetComponentInParent<Spot>().CorrectAnswer();

        }

        else
        {
            answer.text = "";
            if (attempts > 1)
            {
                tryAgain.SetActive(true);
            }
            wrongAnswer = true;
            attempts = attempts - 1;
            //score = 0;
            //Debug.Log("Väärin");
        }


        //UpdateScore();

        //button.onClick.RemoveAllListeners();
        //RandomNumbers();
    }
    void Multiplication()
    {
        sign.text = "X";

        firstNumberInt = Random.Range(1, 10);

        secondNumberInt = Random.Range(1, 10);

        firstNumber.SetText(firstNumberInt.ToString());

        secondNumber.SetText(secondNumberInt.ToString());

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(MultiplicationCheck);
    }

    void MultiplicationCheck()
    {
        answerInt = int.Parse(answer.text);

        if (answerInt == firstNumberInt * secondNumberInt)
        {
            GetComponentInParent<Spot>().isOnGiraffe = true;
            GetComponentInParent<Spot>().CorrectAnswer();
            //score++;
            //Debug.Log("Oikein");
        }

        else
        {
            answer.text = "";
            if (attempts > 1)
            {
                tryAgain.SetActive(true);
            }
            wrongAnswer = true;
            attempts = attempts - 1;
            
            //score = 0;
            //Debug.Log("Väärin");
        }


        //UpdateScore();

        //button.onClick.RemoveAllListeners();
        //RandomNumbers();
    }
    void Division()
    {
        sign.text = "/";

        secondNumberInt = Random.Range(1, 10);

        firstNumberInt = secondNumberInt * Random.Range(1, 4);

        firstNumber.SetText(firstNumberInt.ToString());

        secondNumber.SetText(secondNumberInt.ToString());

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(DivisionCheck);
    }
    void DivisionCheck()
    {
        answerInt = int.Parse(answer.text);

        if (answerInt == firstNumberInt / secondNumberInt)
        {
            GetComponentInParent<Spot>().isOnGiraffe = true;
            GetComponentInParent<Spot>().CorrectAnswer();
            //score++;
            //Debug.Log("Oikein");
        }

        else
        {
            answer.text = "";
            if (attempts > 1)
            {
                tryAgain.SetActive(true);
            }
            wrongAnswer = true;
            attempts = attempts - 1;
            //score = 0;
            //Debug.Log("Väärin");
        }


        //UpdateScore();

        //button.onClick.RemoveAllListeners();
        //RandomNumbers();
    }
    void UpdateScore()
    {
        //scoreAmount.text = score.ToString();
    }

}
