using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Script.Utility;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private float moveSpeedX = 1f;
    private bool isAlive;
    private Animator animator;
    [SerializeField] private bool isHedgehog;
    [SerializeField] private float destroyDelay = 1f;

    void Start()
    {
        isAlive = true;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (!isHedgehog)
        {
            animator.SetBool(IsBee, true);
        }
    }

    void Update()
    {
        if (isAlive)
        {
            Move();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeedX = -moveSpeedX;
        FlipSprite();
    }

    private void Move()
    {
        rigidBody.velocity = new Vector2(moveSpeedX, rigidBody.velocity.y);
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(GetMoveDirection(moveSpeedX), 1f);
    }

    private float GetMoveDirection(float inputX)
    {
        return Mathf.Sign(inputX);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(BulletTag))
        {
            isAlive = false;
            Dying();
        }
    }
    
    private void Dying()
    {
        if (isHedgehog)
        {
            animator.SetTrigger(DyingHedgehogTrigger);
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        { 
            if (GetMoveDirection(moveSpeedX) > 0)
            {
                moveSpeedX = -moveSpeedX;
            }
            rigidBody.velocity = new Vector2(0f, moveSpeedX);
            animator.SetTrigger(DyingBeeTrigger);
        }
        Destroy(this.gameObject, destroyDelay);
    }
}


