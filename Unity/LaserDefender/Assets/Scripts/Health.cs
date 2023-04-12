using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float maximumHealth = 50;
    [SerializeField] private float score = 50;
    [SerializeField] private bool isPlayer;
    [SerializeField] private bool isBoss;
    [SerializeField] private ParticleSystem explosionEffect;
    private CameraShake cameraShake;
    private float health;
    private bool isDead;
 
    private void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        ResetHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageMaker damageMaker = collision.GetComponent<DamageMaker>();
        if (damageMaker != null && !isDead)
        {
            TakeDamage(damageMaker.GetDamage());
            damageMaker.Destroy();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (isPlayer)
        {
            cameraShake.Play();
            GameManager.GetInstance().UpdateSlider(health);
        }
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        if (isBoss)
        {
            GameManager.GetInstance().SetIsBossDead(true);
            GameManager.GetInstance().LoadEndScene();
        }
        else
        {
            if (!isPlayer)
            {
                GameManager.GetInstance().IncrementScore(score);
            }
            else
            {
                GameManager.GetInstance().LoadEndScene(); 
            }
        }
        PlayParticleEffect();
        Destroy(gameObject);
    }

    private void PlayParticleEffect()
    {
        ParticleSystem instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        ParticleSystem.MainModule main = instance.main;
        Destroy(instance.gameObject, main.duration);
    }

    public void ResetHealth()
    {
        health = maximumHealth;
    }

    public float GetMaximumHealth()
    {
        return maximumHealth;
    }
}