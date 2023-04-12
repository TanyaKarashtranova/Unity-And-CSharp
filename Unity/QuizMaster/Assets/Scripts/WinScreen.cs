using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private ScoreKeeper scoreKeeper;
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private AudioClip applause;
    private const int MinimumScore = 50;
    private int result;

    private void Start()
    {
        result = scoreKeeper.GetScore();
        ShowFinalScore();
        if (result >= MinimumScore)
        {
            GetComponent<AudioSource>().PlayOneShot(applause);
        }
    }

    private void ShowFinalScore()
    {
        if (result >= MinimumScore)
        {
            finalScore.text = "Compliments!\n You scored : " + result + "%";
        }
        else
        {
            finalScore.text = "Sorry!You didn't give your best!\n You scored : " + result + "%";
        }
    }
}
