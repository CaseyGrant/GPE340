using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Color gizmoColor = Color.white;
    public GameObject enemy;
    public List<Transform> Spawners;
    public int maxEnemyCount = 4;
    public int currentEnemyCount = 0;

    void Update()
    {
        while (currentEnemyCount < maxEnemyCount) // if there is less enemies than the maximum
        {
            Instantiate(enemy, Spawners[currentEnemyCount]); // spawn an enemy
            currentEnemyCount++; // increase the number of current enemies
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor; // sets the gizmos color
        Gizmos.DrawSphere(transform.position, 1); // creates the gizmo
    }
}
