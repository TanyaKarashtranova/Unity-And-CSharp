using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private float score = 0;

    public float GetScore()
    {
        return score;
    }

    public void IncrementScore(float newScore)
    {
        score += newScore;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
