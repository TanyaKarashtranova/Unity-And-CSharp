using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets.Scripts.Utility;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float loadDelayTime = 1f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSound;
    private PlayerController playerController;
    private bool hasCrashed = false;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Ground) && !hasCrashed)
        {
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            playerController.DisableControl();
            hasCrashed = true;
            StartCoroutine(RestartGame());
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(loadDelayTime);
        ReloadScene();
    }
}
 