using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[CreateAssetMenu(menuName = "Quiz question", fileName = "New Question")]
public class QuestionSo : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question here ";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string GetQuestion()
    {
        return question;
    }
    public string GetAnswers(int index)
    {
        return answers[index];
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public static implicit operator string(QuestionSo v)
    {
        throw new NotImplementedException();
    }
}
