using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSo> questions= new List<QuestionSo>();
     QuestionSo currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer; 

    void Start()
    { 
        timer=FindObjectOfType<Timer>();    
        

    
    }
     void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly&&!timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {

            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            currentQuestion.GetAnswers(correctAnswerIndex);
            string correctAnswer = currentQuestion.ToString();
            questionText.text = "Sorry, the correct answer was;\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;



        }


    }
    public void OnAnswerselected(int index)
    {
        hasAnsweredEarly = true;   
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    private void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();


        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswers(i);
        }
    }

    void SetButtonState( bool state )
    {
        for (int i =0;i < answerButtons.Length;i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;


        }
    } 
    void GetNextQuestion() 
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefeaultButtonSpirates();
            GetRandomQuestion();
            DisplayQuestion();
        }    
    
    }
    void GetRandomQuestion()
    {
        int index = UnityEngine.Random.Range(0, questions.Count);
        currentQuestion= questions[index];
        if (questions.Contains(currentQuestion)) {
            questions.Remove(currentQuestion);
        }
    }

    void SetDefeaultButtonSpirates()
    {
        Image defaultImage;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            defaultImage = answerButtons[i].GetComponent<Image>();
            defaultImage.sprite = defaultAnswerSprite;
        }
    }
}
