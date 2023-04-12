using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreAndHealthUIDisplay : MonoBehaviour
{
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private Health playerHealth;
    
    private void Start()
    {
        playerHealthSlider.maxValue = playerHealth.GetMaximumHealth();
    }

    public void UpdateScore(float score)
    {
        playerScore.text = score.ToString("00000000000");
    }

    public void UpdateSlider(float health)
    {
        playerHealthSlider.value = health;
    }

    public void ResetInformation()
    {
        UpdateSlider(playerHealthSlider.maxValue);
        UpdateScore(0);
    }
}
