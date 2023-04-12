using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="WaveConfiguration",fileName = "NewWaveConfiguration")]
public class WaveConfigurationSO : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float enemyMovementSpeed = 2f;
 
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemy(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetEnemyMovementSpeed()
    {
        return enemyMovementSpeed;
    }

    public Transform GetPointOfPath(int index)
    {
        return pathPrefab.GetChild(index);
    }

    public List<Transform> GetAllPointsOfPath()
    {
        List<Transform> points = new List<Transform>();
        foreach (Transform point in pathPrefab)
        {
            points.Add(point);
        }
        return points;
    }
}
