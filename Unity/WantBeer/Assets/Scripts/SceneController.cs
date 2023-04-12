using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;
    private enum SceneIndex
    {
        AuthenticatorScene,
        LoginScene,
        RegistrationScene,
        HomeScene,
        DetailsScene,
    }

    [Header("Animation between scene")]
    [SerializeField] private GameObject animationUI;
    [SerializeField] private Animator animator;

    public float clipDuration;
    private float goBackClipDuration;
    private const string IsGoingBack = "isGoingBack";
    private const string IsLooping = "isLooping";

    private void Awake()
    {
        if (instance != null && instance != this)
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

    public static SceneController GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        if (animator.runtimeAnimatorController.animationClips[0] != null)
        {
            clipDuration = animator.runtimeAnimatorController.animationClips[0].length;
        }
        if (animator.runtimeAnimatorController.animationClips[1])
        {
            goBackClipDuration = animator.runtimeAnimatorController.animationClips[1].length;
        }
    }

    private void LoadScene(SceneIndex sceneIndex)
    {
        StartCoroutine(ShowTransitionAnimation());
        SceneManager.LoadScene((int)sceneIndex);
    }

    private void LoadSceneWithLoopAnimation(SceneIndex sceneIndex)
    {        
        StartTransitionAnimation();
        SceneManager.LoadScene((int)sceneIndex);
    }

    public void LoadRegistrationScene()
    {
        LoadScene(SceneIndex.RegistrationScene);
    }

    public void LoadLoginScene()
    {
        LoadScene(SceneIndex.LoginScene);
    }

    public void LoadHomeScene()
    {
        LoadSceneWithLoopAnimation(SceneIndex.HomeScene);
    }

    private IEnumerator ShowTransitionAnimation()
    {
        animationUI.SetActive(true);
        yield return new WaitForSeconds(clipDuration);
        animationUI.SetActive(false);
    }

    private IEnumerator ShowGoBackAnimation()
    {
        animationUI.SetActive(true);
        animator.SetBool(IsGoingBack, true);
        yield return new WaitForSeconds(goBackClipDuration);
        animator.SetBool(IsGoingBack, false);
        animationUI.SetActive(false);
    }

    private void StartTransitionAnimation()
    {
        animationUI.SetActive(true);
        animator.SetBool(IsLooping, true);
    }

    public void StopTransitionAnimation()
    {
        animationUI.SetActive(false);
        animator.SetBool(IsLooping, false);
    }

    public void LoadAuthenticatorScene()
    {
        StartCoroutine(ShowGoBackAnimation());
        SceneManager.LoadScene((int)SceneIndex.AuthenticatorScene);
        /*LoadScene(SceneIndex.AuthenticatorScene);*/
    }

    public void LoadDetailsScene(Beer beer)
    {
        ApplicationSession.GetInstance().SetCurrentBeer(beer);
        LoadSceneWithLoopAnimation(SceneIndex.DetailsScene);
    }
}