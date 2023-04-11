using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Timer : MonoBehaviour
{


    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public float fillFraction;
    public bool isAnsweringQuestion;
    float timerValue;
    public bool loadNextQuestion;



    void Update()
    {
        UpdateTimer();
        
    }

    void UpdateTimer() 
    {
        timerValue-=Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else 
            {
                isAnsweringQuestion=false;
                timerValue = timeToShowCorrectAnswer;

            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion=true;
                timerValue = timeToCompleteQuestion; 
                loadNextQuestion= true;
            }

        }
    
    
    
    }
    public void CancelTimer() { timerValue = 0; }
}
