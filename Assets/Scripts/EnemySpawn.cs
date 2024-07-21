using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    [SerializeField] List<WaveInfoSO> Waves;
    [SerializeField] float delayBetweenWavesSecond;
    [SerializeField] WaveInfoSO currentWave;

    async Task SpawnEnemy() {
        foreach (WaveInfoSO wave in Waves) {
            if (this == null || !this.enabled) return;

            currentWave = wave;
            foreach (GameObject enemyPrefab in wave.GetEnemyPrefabs()) {
                if (this == null || !this.enabled) return;

                Instantiate(enemyPrefab, wave.GetWayPoints()[0].position, Quaternion.identity, transform);
                await Task.Delay(wave.GetSpawnRateMiliecond());
            }

            delayBetweenWavesSecond *= 1000;
            await Task.Delay((int)delayBetweenWavesSecond);
        }
    }

    private async void Start() {
        await SpawnEnemy();
    }

    public WaveInfoSO GetCurrentWave() {
        return currentWave;
    }
}
