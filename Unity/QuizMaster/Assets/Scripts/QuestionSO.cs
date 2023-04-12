using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestionForGame", fileName = "NewQuestion")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 4)]
    [SerializeField] private string question;
    [SerializeField] private string[] answers = new string[4];
    [Range(0,3)]
    [SerializeField] private int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
