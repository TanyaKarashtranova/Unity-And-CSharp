using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRigidbody;
    [SerializeField] private float speedX = 5f;
    [SerializeField] private float destroyDelayWhenHitPlatform = 0.1f;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        bulletRigidbody.velocity = new Vector2(bulletRigidbody.transform.localScale.x *speedX, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject, destroyDelayWhenHitPlatform);
    }

    public void SetBulletDirection(float directionX, float directionY)
    {
        bulletRigidbody.transform.localScale = new Vector3 (directionX, directionY, 0f);
    }
}
