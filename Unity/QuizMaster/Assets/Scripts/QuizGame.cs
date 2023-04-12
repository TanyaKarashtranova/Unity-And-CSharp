using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] private List<QuestionSO> questions;
    [SerializeField] private TextMeshProUGUI questionText;
    private QuestionSO currentQuestion;
    private int questionNumber;
    
    [Header("Answer")]
    [SerializeField] private GameObject[] answerButtons = new GameObject[4];
    [SerializeField] private int correctAnswerIndex;
    public bool hasAnswered;
    private const int NoAnswer = -1;

    [Header("Button Sprite")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;
    [SerializeField] private Sprite wrongAnswerSprite;

    [Header("Timer")]
    [SerializeField] private Image timerImage;
    [SerializeField] private Timer timer;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScoreKeeper scoreKeeper;

    [Header("Progress")]
    [SerializeField] private Slider progressBar;
    private bool isGameCompleted;

    [Header("Effects")]
    [SerializeField] private AudioClip wrongChoise;
    [SerializeField] private AudioClip rightChoise;

    private void Start()
    {
        questionNumber = questions.Count;
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
        DisplayQuestion();
    }

    private void Update()
    {
        timerImage.fillAmount = timer.GetFillAmount();
        if (timer.isTimeToLoadNextQuestion)
        {
            hasAnswered = false;
            GetNextQuestion();
            timer.isTimeToLoadNextQuestion = false;
        }
        else if (!hasAnswered && !timer.IsAnsweringQuestion())
        {
            DisplayAnswer(NoAnswer);
            SetButtonState(false);
        }
        CheckForFinishingGame();
    }

    public void OnAnswerSelected(int index)
    {
        hasAnswered = true;
        timer.CancelTimer();
        SetButtonState(false);
        DisplayAnswer(index);
    }

    public void DisplayQuestion()
    {
        GetRandomQuestion();
        questionText.text = currentQuestion.GetQuestion();
        correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI answerText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            answerText.text = currentQuestion.GetAnswer(i);
        }
    }
    
    public void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    public void GetRandomQuestion()
    {
        if (questions.Count > 0)
        {
            int currentQuestionIndex = Random.Range(0, questions.Count);
            currentQuestion = questions[currentQuestionIndex];
        }
    }

    public void GetNextQuestion()
    {     
        scoreKeeper.IncrementPassedQuestions();
        DisplayScore();
        ChangeSliderValue();
        SetAllButtonsDefautImage();
        SetButtonState(true);
        questions.Remove(currentQuestion);
        DisplayQuestion();
    }

    public void DisplayAnswer(int index)
    {
        if (index == correctAnswerIndex)
        {
            scoreKeeper.IncrementRightAnsweredQuestions();
            questionText.text = "Correct";
            GetComponent<AudioSource>().PlayOneShot(rightChoise);
        }
        else
        {
            if (index >= 0)
            {
                ChangeButtonImage(wrongAnswerSprite, index);
                GetComponent<AudioSource>().PlayOneShot(wrongChoise);
            }
            questionText.text = currentQuestion.GetAnswer(correctAnswerIndex);
        }
        ChangeButtonImage(correctAnswerSprite, correctAnswerIndex);
    }

    public void ChangeButtonImage(Sprite buttonChangeImage,int index)
    {
        Image buttonImage = answerButtons[index].GetComponent<Image>();
        buttonImage.sprite = buttonChangeImage;
    }

    public void SetAllButtonsDefautImage()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + scoreKeeper.GetScore() + "%";
    }

    public void ChangeSliderValue()
    {
        progressBar.value++;
    }

    public void CheckForFinishingGame()
    {
        if (scoreKeeper.GetPassedQuestions() == questionNumber)
        {
            isGameCompleted = true;
        }
    }

    public bool IsGameCompleted()
    {
        return isGameCompleted;
    }
}
