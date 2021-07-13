using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Color gizmoColor = Color.white;
    public GameObject enemy;
    public List<Transform> Spawners;
    public int maxEnemyCount = 4;
    public int currentEnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (currentEnemyCount < maxEnemyCount)
        {
            Instantiate(enemy, Spawners[currentEnemyCount]);
            currentEnemyCount++;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, 1);
    }

}
