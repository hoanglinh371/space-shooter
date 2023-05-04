using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeSpanwnEnemy = 1f;
    WaveConfig currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0, 0, 180), transform);
                    yield return new WaitForSeconds(timeSpanwnEnemy);
                }
            }
        } while (true);
    }
}
