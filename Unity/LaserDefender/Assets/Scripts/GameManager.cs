using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private Health playerHealth;
    [SerializeField] private ScoreAndHealthUIDisplay scoreAndHealthUIDisplay;
    [SerializeField] private ScoreKeeper scoreKeeper;
    private bool isBossDead = false;

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadEndScene()
    {
        SceneManager.GetInstance().LoadEndScene();
    }
    
    public float GetScore()
    {
        return scoreKeeper.GetScore();
    }

    public void UpdateSlider(float health)
    {
        scoreAndHealthUIDisplay.UpdateSlider(health);
    }

    public void ResetScore()
    {
        scoreKeeper.ResetScore();
    }

    public void IncrementScore(float score)
    {
        scoreKeeper.IncrementScore(score);
        scoreAndHealthUIDisplay.UpdateScore(scoreKeeper.GetScore());
    }

    public void ResetUIInformation()
    {
        scoreAndHealthUIDisplay.ResetInformation();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void SetIsBossDead(bool state)
    {
        isBossDead = state;
    }

    public bool IsBossDead()
    {
        return isBossDead;
    }
}
