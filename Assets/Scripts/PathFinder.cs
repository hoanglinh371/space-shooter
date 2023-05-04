using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    SpawnEnemy spawnEnemy;
    WaveConfig waveConfig;
    Player player;
    int waypointIndex = 0;
    List<Transform> waypoints;

    void Awake()
    {
        spawnEnemy = FindObjectOfType<SpawnEnemy>();
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        waveConfig = spawnEnemy.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            player.GetComponent<Health>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
