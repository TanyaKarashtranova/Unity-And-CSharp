using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;
    private int playersLifes;
    private int playerScore;
    private int currentSceneIndex = 0;
    private int initialLifes = 3;
    private int initialScore = 0;
    private bool isRestartingGame;
    [SerializeField] private TextMeshProUGUI lifes;
    [SerializeField] private TextMeshProUGUI score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start()
    {
        ResetLifesAndPoints();
        UpdateLifesOnScene();
        UpdateScoreOnScene();
        isRestartingGame = false;
    }

    private void UpdateLifesOnScene()
    {
        lifes.text = playersLifes.ToString();
    }

    private void UpdateScoreOnScene()
    {
        score.text = playerScore.ToString();
    }

    public void ResetGameSession()
    {
        ScenePersist.Instance.ResetScenePersist();
        currentSceneIndex = 0;
        SceneManager.LoadScene(currentSceneIndex);
        ResetLifesAndPoints();
        UpdateLifesOnScene();
        UpdateScoreOnScene();
    }

    private void TakeLife()
    {
        playersLifes--;
    }

    public void AddPoints(int points)
    {
        playerScore += points;
        UpdateScoreOnScene();         
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void IncrementSceneIndex()
    {
        if (currentSceneIndex >= SceneManager.sceneCountInBuildSettings - 1)
        {
            isRestartingGame = true; 
        }
        else
        {
            currentSceneIndex++;
        }
    }

    public void LoadNextScene()
    {        
        IncrementSceneIndex();
        if (!isRestartingGame)
        {
            ScenePersist.Instance.ResetScenePersist();
            SceneManager.LoadScene(currentSceneIndex);
        }
        else 
        {
            ResetGameSession();
            isRestartingGame = false;
        }
    }

    private void ResetLifesAndPoints()
    {
        playersLifes = initialLifes;
        playerScore = initialScore;
    }

    public void ManageSceneWhenPlayerDead()
    {
        TakeLife();
        if (playersLifes <= 0)
        {
            ResetGameSession();
        }
        else 
        {
            ReloadCurrentScene();
            UpdateLifesOnScene();
        }
    }       
}
