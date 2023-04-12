using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float paddingLeft;
    private float paddingRight;
    private float paddingUp = 4f;
    private float paddingDown = 1.5f;
    private Vector2 minPoint;
    private Vector2 maxPoint;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private Shooter shooter;
    private float step;

    [Header("Touch parameters")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float minimumSwipeTime = 0.006f;
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private Vector2 currentInput;
    private Vector2 target;
    private float endTime;
    private float minimumMoveDistanceForSwipe = 0.5f;
    private int startFingerId;
    private int endFingerId;

    private void Start()
    {
        shooter = GetComponent<Shooter>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        paddingLeft = spriteRenderer.bounds.size.x / 2;
        paddingRight = spriteRenderer.bounds.size.y / 2;
        mainCamera = Camera.main;
        minPoint = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxPoint = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        target = transform.position;       
    }

    private void Update()
    {
        ProcessInputTouch();
        Move();
        Fire();
    }

    private void Move()
    {
        step = moveSpeed * Time.deltaTime;
        if (transform.position.x != target.x || transform.position.y != target.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }

    private void Fire()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                SetParametersFromTouch(touch);
                if (IsTouchPositonFromStartAndEndPhaseSame() && IsFingerIdFromTouchSameAtStartAndEndPhase())
                {
                    shooter.ShootOneProjectile();
                }
            }
        }
    }

    private bool IsTouchPositonFromStartAndEndPhaseSame()
    {
        return touchStartPosition == touchEndPosition;
    }

    private bool IsFingerIdFromTouchSameAtStartAndEndPhase()
    {
        return startFingerId == endFingerId;
    }

    private void ProcessInputTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                SetParametersFromTouch(touch);
                target = CalculateTargetPositionToMoveTorwards();
            }
        }
    }

    private void SetParametersFromTouch(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                startFingerId = touch.fingerId;
                touchStartPosition = mainCamera.ScreenToWorldPoint(touch.position);
                break;
            case TouchPhase.Ended:
                endFingerId = touch.fingerId;
                touchEndPosition = mainCamera.ScreenToWorldPoint(touch.position);
                endTime = touch.deltaTime;
                break;
        }
    }

    private bool IsSwipeTimeFromTouchEnough()
    {
        return endTime > minimumSwipeTime;
    }

    private Vector2 CalculateTargetPositionToMoveTorwards()
    {
        if (IsSwipeTimeFromTouchEnough() && IsSwipeDistanceFromTouchEnough() && IsFingerIdFromTouchSameAtStartAndEndPhase())
        {
            currentInput = new Vector2((touchEndPosition.x - touchStartPosition.x), (touchEndPosition.y - touchStartPosition.y));
        }
        else
        {
            currentInput = new Vector2(0, 0);
        }
        return new Vector2(Mathf.Clamp((transform.position.x + currentInput.x), minPoint.x + paddingLeft, maxPoint.x - paddingRight),
                             Mathf.Clamp((transform.position.y + currentInput.y), minPoint.y + paddingDown, maxPoint.y - paddingUp));
    }

    private bool IsSwipeDistanceFromTouchEnough()
    {
        return (Mathf.Abs(touchEndPosition.x - touchStartPosition.x) > minimumMoveDistanceForSwipe
                   || Mathf.Abs(touchEndPosition.y - touchStartPosition.y) > minimumMoveDistanceForSwipe);
    }
}
