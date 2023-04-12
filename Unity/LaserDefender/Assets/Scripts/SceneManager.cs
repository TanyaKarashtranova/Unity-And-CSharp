using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance;
    private enum SceneIndex
    {
        StartScene,
        GameScene,
        EndScene,
    }
    private const string StartTrigger = "start";
    private const string EndTrigger = "end";
    private const string IsEnded = "isEnded";

    [Header("Animation")]
    [SerializeField] private Animator transition;
    private float firstClipDuration;
    private float secondClipDuration;
   
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

    private void Start()
    {
        firstClipDuration = transition.runtimeAnimatorController.animationClips[0].length;
        secondClipDuration = transition.runtimeAnimatorController.animationClips[1].length;
    }

    public static SceneManager GetInstance()
    {
        return instance;
    }

    public void LoadStartScene()
    {
        StartCoroutine(LoadLevel((int)SceneIndex.StartScene));
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadLevel((int)SceneIndex.GameScene));
    }
    
    public void LoadEndScene()
    {
        StartCoroutine(LoadLevel((int)(SceneIndex.EndScene)));
    }
    
    private IEnumerator LoadLevel(int sceneIndex)
    {
        transition.SetBool(IsEnded, false);
        transition.SetTrigger(StartTrigger);
        yield return new WaitForSeconds(firstClipDuration);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        transition.SetTrigger(EndTrigger);
        yield return new WaitForSeconds(secondClipDuration);
        transition.SetBool(IsEnded, true);
        if (sceneIndex == 1)
        {
            GameManager.GetInstance().ResetScore();
            GameManager.GetInstance().ResetUIInformation();
        }
    }
}
