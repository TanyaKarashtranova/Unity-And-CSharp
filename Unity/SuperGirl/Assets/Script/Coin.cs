using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Script.Utility;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points = 100;
    [SerializeField] private bool isCollected;
    [SerializeField] private AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag) && !isCollected)
        {
            GetComponent<AudioSource>().PlayOneShot(coinSound);
            isCollected = true;
            Destroy(GetComponent<SpriteRenderer>());
            GameSession.Instance.AddPoints(points);
            Destroy(gameObject, coinSound.length);
        }
    }
}
