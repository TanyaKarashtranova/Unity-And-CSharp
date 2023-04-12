using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject quiz;
    [SerializeField] private GameObject end;
    private QuizGame quizGame;

    private void Awake()
    {
        quiz.SetActive(true);
        end.SetActive(false);
    }

    private void Start()
    {
        quizGame = quiz.GetComponent<QuizGame>();
    }

    private void Update()
    {
        ChangeActiveScreen();
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ChangeActiveScreen()
    {
        if (quizGame.IsGameCompleted())
        {
            quiz.SetActive(false);
            end.SetActive(true);
        }
    }
}

