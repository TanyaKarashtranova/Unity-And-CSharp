using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private static AudioPlayer instance;
    [SerializeField] private AudioClip enemyShootClip;
    [SerializeField] private AudioClip playerShootClip;
    [SerializeField] private float volume = 0.4f;

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

    public static AudioPlayer GetInstance()
    {
        return instance;
    }

    private void PlayClip(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }

    public void PlayEnemyShootClip()
    {
        PlayClip(enemyShootClip);
    }

    public void PlayPlayerShootClip()
    {
        PlayClip(playerShootClip);
    }
}
