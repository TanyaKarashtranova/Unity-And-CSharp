using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static Assets.Script.Utility;

public class PlayerController : MonoBehaviour
{
    [Header("SpeedChangerParameters")]
    [SerializeField] private float moveSpeedX = 2f;
    [SerializeField] private float climbSpeedY = 2f;
    [SerializeField] private float jumpSpeedY = 10f;
    [SerializeField] private Vector2 velocityForDramaticDyingEffect;
    [SerializeField] private float timeForDelay = 1f;

    [Header("GameObjectComponents")]
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CapsuleCollider2D playerBody;
    [SerializeField] private float startGravityScale;
    
    [Header("Flags")]
    public bool IsAlive;
    private bool isShooting;
    private bool isJumping;

    [Header("ChildComponents")]
    [SerializeField] private Transform gun;
    [SerializeField] private Bullet bullet;

    private Vector2 moveInput;
    
    private void Start()
    {
        IsAlive = true;
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBody = GetComponent<CapsuleCollider2D>();
        startGravityScale = playerRigidbody.gravityScale;
        isJumping = false;
    }

    private void Update()
    {
        if (IsAlive)
        {
            Walk();
            Jump();
            ClimbLadder();
            Swim();
            FlipSprite(moveInput.x);
            CheckForHazards();
            if (isShooting)
            {
                Shoot();
            }
        }
    }

    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && !isJumping && IsAlive
            && (DoesPlayerBodyHaveTouchedLayer(PlatformLayer) 
                    || DoesPlayerBodyHaveTouchedLayer(WaterLayer)))
        {
            isJumping = true;
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpSpeedY);
        }
    }

    private void OnFire()
    {
        isShooting = true;
        Bullet bulletInstance = Instantiate(bullet, gun.position, transform.rotation);
        bulletInstance.SetBulletDirection(Mathf.Sign(transform.localScale.x), Mathf.Sign(transform.localScale.y));
    }

    private bool DoesPlayerMove(float inputX)
    {
        if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private float GetMoveDirection(float inputX)
    {
        return Mathf.Sign(inputX);
    }

    private void FlipSprite(float inputX)
    {

        if (DoesPlayerMove(inputX))
        {
            transform.localScale = new Vector2(GetMoveDirection(inputX), 1f);
        }
    }

    private bool DoesPlayerBodyHaveTouchedLayer(string layer)
    {
        return playerBody.IsTouchingLayers(LayerMask.GetMask(layer));
    }

    private void Walk()
    {
        if (DoesPlayerMove(moveInput.x) 
            && (DoesPlayerBodyHaveTouchedLayer(PlatformLayer) 
                    || DoesPlayerBodyHaveTouchedLayer(BouncingLayer)))
        {
            playerRigidbody.velocity = new Vector2(moveSpeedX * moveInput.x, playerRigidbody.velocity.y);
            playerAnimator.SetBool(IsWalking, true);
        }
        else
        {
            playerAnimator.SetBool(IsWalking, false);
        }
    } 
    
    private void Jump()
    {
        if ((!DoesPlayerBodyHaveTouchedLayer(PlatformLayer) 
                 && !DoesPlayerBodyHaveTouchedLayer(WaterLayer) 
                      && !DoesPlayerBodyHaveTouchedLayer(LadderLayer)))
        {
            playerAnimator.SetBool(IsJumping, true);
        }
        else
        {
            playerAnimator.SetBool(IsJumping, false);
            isJumping = false;
        }
        if (isShooting)
        {
            Shoot();
        }
    }

    private void Swim()
    {
        if (DoesPlayerMove(moveInput.x) && DoesPlayerBodyHaveTouchedLayer(WaterLayer))
        { 
            playerRigidbody.velocity = new Vector2(moveSpeedX * moveInput.x, playerRigidbody.velocity.y);
            playerAnimator.SetBool(IsSwimming, true);
        }
        else
        {
            playerAnimator.SetBool(IsSwimming, false);
        }
    }

    private void ClimbLadder()
    {
        if (playerBody.IsTouchingLayers(LayerMask.GetMask(LadderLayer)))
        {
            playerRigidbody.gravityScale = 0;
            playerRigidbody.velocity = new Vector2(moveInput.x, climbSpeedY * moveInput.y);
            playerAnimator.SetBool(IsClimbing, true);
            if (DoesPlayerMove(moveInput.y))
            {
                playerAnimator.SetBool(IsClimbing, true);
            }
            else
            {
                playerAnimator.SetBool(IsClimbing, false);
            }
            if (DoesPlayerMove(moveInput.x))
            {
                playerAnimator.SetBool(IsWalking, true);

            }
            else
            {
                playerAnimator.SetBool(IsWalking, false);
            }
            if (DoesPlayerMove(moveInput.x) && DoesPlayerMove(moveInput.y) && 
                playerBody.IsTouchingLayers(LayerMask.GetMask(LadderLayer)))
            {
                playerAnimator.SetBool(IsClimbing, false);
            }
        }
        else
        {
            playerRigidbody.gravityScale = startGravityScale;
        }
    }

    private void Shoot()
    { 
        playerAnimator.SetTrigger(ShootingTrigger);
        isShooting = false;
    }

    private void CheckForHazards()
    {
        if (DoesPlayerBodyHaveTouchedLayer(HazardLayer))
        {
            IsAlive = false;
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        velocityForDramaticDyingEffect = new Vector2(playerRigidbody.velocity.x, jumpSpeedY);
        playerAnimator.SetTrigger(DyingTrigger);
        playerRigidbody.velocity = velocityForDramaticDyingEffect;
        playerBody.enabled = false;
        yield return new WaitForSeconds(timeForDelay);
        GameSession.Instance.ManageSceneWhenPlayerDead();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(EnemyTag))
        {
            IsAlive = false;
            StartCoroutine(Die());
        }
    }
}
