using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{ 
    [SerializeField] private float timeToShowTheCorrectAnswer = 10f;
    [SerializeField] private float timeToShowQuestion = 20f;
    private bool isAnsweringQuestion;
    private float fillAmount;
    private float timerValue;
    public bool isTimeToLoadNextQuestion;
    private const float CancelTimerValue = 0;
   
    private void Start()
    {
        timerValue = timeToShowQuestion;
        isAnsweringQuestion = true;
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            fillAmount = timerValue / timeToShowQuestion;
            if (timerValue <= CancelTimerValue)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowTheCorrectAnswer;
            }
        }
        else
        {
            fillAmount = timerValue / timeToShowTheCorrectAnswer;
            if (timerValue <= CancelTimerValue)
            {
                isAnsweringQuestion = true;
                timerValue = timeToShowQuestion;
                isTimeToLoadNextQuestion = true;
            }
        }
    }

    public void CancelTimer()
    {
        timerValue = CancelTimerValue;
    }

    public float GetFillAmount()
    {
        return fillAmount;
    }

    public bool IsAnsweringQuestion()
    {
        return isAnsweringQuestion;
    }
}
