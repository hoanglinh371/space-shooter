using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float moveSpeed = 5f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefabs.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new();
        foreach(Transform path in pathPrefabs)
        {
            waypoints.Add(path);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
}
