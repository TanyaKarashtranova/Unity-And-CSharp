using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private bool isBoss;
    [SerializeField] private BossLaserShooter bossLaserShooter;
    private EnemySpawner enemySpawner;
    private WaveConfigurationSO waveConfiguration;
    private List<Transform> wayPoints;
    private Vector3 currentPosition;
    private Vector3 nextPosition;
    private int currentWayPointIndex = 0;
    private float timeBeforeBossGoBack = 3f;
    private float moveSpeed;
    private bool isTimeForBossToGoHome = false;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void Start()
    {
        waveConfiguration = enemySpawner.GetCurrentWave();
        wayPoints = waveConfiguration.GetAllPointsOfPath();
        moveSpeed = waveConfiguration.GetEnemyMovementSpeed();
    }

    private void Update()
    {
        if (!isBoss)
        {
            EnemyWalkOnThePath();
        }
        else if (!bossLaserShooter.enabled)
        {
            BossWalkOnThePath();
        }
        else if (!bossLaserShooter.IsBossStillShoot())
        {
            if (!isTimeForBossToGoHome)
            {
                StartCoroutine(WaitBeforeGoBack());
            }
            else
            {
                GoBack();
            }
        }
    }

        public void EnemyWalkOnThePath()
    {
        if (currentWayPointIndex < wayPoints.Count)
        {
            MoveGameObjectToNextPointOfThePath();
            if (transform.position == nextPosition)
            {
                currentWayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void MoveGameObjectToNextPointOfThePath()
    {
        currentPosition = transform.position;
        nextPosition = wayPoints[currentWayPointIndex].position;
        transform.position = Vector3.MoveTowards(currentPosition, nextPosition, moveSpeed * Time.deltaTime);
    }

    private void RotateBoss()
    {
        Vector3 position = nextPosition - currentPosition;
        Quaternion rotation = Quaternion.LookRotation(position, Vector3.back);
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
    }

    public void BossWalkOnThePath()
    {
        if (currentWayPointIndex < wayPoints.Count - 1)
        {
            MoveGameObjectToNextPointOfThePath();
            RotateBoss();
            if (transform.position == nextPosition)
            {
                currentWayPointIndex++;
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            bossLaserShooter.enabled = true;
        }
    }

    private IEnumerator WaitBeforeGoBack()
    {
        yield return new WaitForSeconds(timeBeforeBossGoBack);
        isTimeForBossToGoHome = true;
    }

    private void GoBack()
    {
        if (currentWayPointIndex > 0)
        { 
            if (transform.position == nextPosition)
            {
                currentWayPointIndex--;
            }
            RotateBoss();
            MoveGameObjectToNextPointOfThePath();
        }
        else
        {
            do
            {
                RotateBoss();
                MoveGameObjectToNextPointOfThePath();
            }
            while (transform.position != nextPosition);
            Destroy(gameObject);
            GameManager.GetInstance().LoadEndScene();
        }
    }
}

