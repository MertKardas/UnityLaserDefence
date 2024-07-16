using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Info", fileName = "New Wave Info")]
public class WaveInfoSO : ScriptableObject
{
    [SerializeField] List <GameObject> enemyPrefabs;
    [SerializeField] Transform path;
    [SerializeField] float enemySpeed;
    [SerializeField] float spawnRateSecond;
    List<Transform> wayPoints; 
    
    public List <Transform> GetWayPoints(){
        wayPoints = new List<Transform>();
        foreach(Transform waypoint in path){
            wayPoints.Add(waypoint);
        }
        return wayPoints; 
    }
    public float GetEnemySpeed() {
        return enemySpeed;
    }
    public List<GameObject> GetEnemyPrefabs() {
        return enemyPrefabs; 
    }
    public int GetSpawnRateMiliecond() {
       float spawnRateMilisecond = spawnRateSecond * 1000;
       return (int)(spawnRateMilisecond);
    }
}
