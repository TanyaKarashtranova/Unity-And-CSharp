using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private int rightAnsweredQuestions = 0;
    private int passedQuestions = 0;

    public void IncrementRightAnsweredQuestions()
    {
        rightAnsweredQuestions++;
    }

    public void IncrementPassedQuestions()
    {
        passedQuestions++;
    }

    public int GetScore()
    {
        return Mathf.RoundToInt(rightAnsweredQuestions / (float)passedQuestions * 100);
    }

    public int GetPassedQuestions()
    {
        return passedQuestions;
    }
}
