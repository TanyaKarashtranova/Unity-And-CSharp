using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utility;

public class DustTrail : MonoBehaviour
{ 
    [SerializeField] private ParticleSystem snowDust;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground))
        {
            snowDust.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground))
        {
            snowDust.Stop();
        }
    }
}
