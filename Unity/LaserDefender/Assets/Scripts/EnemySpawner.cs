using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigurationSO> wavesConfiguration;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float timeBetweenEnemySpawns = 4f;
    private WaveConfigurationSO currentWave;
    private float timeBeforeStartEnemies = 1f;
     
    private void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    private IEnumerator SpawnEnemyWaves()
    {
        yield return new WaitForSeconds(timeBeforeStartEnemies);
        foreach (WaveConfigurationSO wave in wavesConfiguration)
        {
            currentWave = wave;
            Vector3 startPosition = currentWave.GetPointOfPath(0).position;
            for (int j = 0; j < currentWave.GetEnemyCount(); j++)
            {
                Instantiate(currentWave.GetEnemy(j), startPosition,
                             Quaternion.Euler(0, 0, 180), transform);
                yield return new WaitForSeconds(timeBetweenEnemySpawns);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public WaveConfigurationSO GetCurrentWave()
    {
        return currentWave;
    }
}
