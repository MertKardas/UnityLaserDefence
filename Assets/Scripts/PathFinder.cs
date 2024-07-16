using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
    WaveInfoSO waveInfoSO;
    Transform targetWayPoint;
    float enemySpeed;
    int pathIndex = 0;
    List<Transform> wayPoints;

    private void Start() {
        EnemySpawn enemySpawn = FindAnyObjectByType<EnemySpawn>();
        waveInfoSO =  enemySpawn.GetCurrentWave(); 
        enemySpeed = waveInfoSO.GetEnemySpeed();
        wayPoints = new List<Transform>(waveInfoSO.GetWayPoints());
        targetWayPoint = wayPoints[1];
        pathIndex = 1;
    }

    private void Update() {
        if (targetWayPoint != null) {
            PathFind();
        }
    }

    private void PathFind() {
        transform.position = Vector2.MoveTowards(transform.position, targetWayPoint.position, enemySpeed * Time.deltaTime);
        if (transform.position == targetWayPoint.position) {
            try {
                targetWayPoint = wayPoints[pathIndex++];
            } catch (ArgumentOutOfRangeException) {
                Destroy(gameObject);
            }
        }
    }
    
   
}
