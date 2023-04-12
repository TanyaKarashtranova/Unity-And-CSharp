using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets.Scripts.Utility;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float loadDelayTime = 0.5f;
    [SerializeField] private ParticleSystem finishEffect;
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Player))
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
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
