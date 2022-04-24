using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField]
    GameObject[] enemies;

    [SerializeField]
    float timeBetweenSpawn;

    [SerializeField]
    float minEnemiesKilledToSpawn = 0f;

    bool started = false;

    private void Update()
    {
        if (GameManager.Instance.enemiesKilled >= minEnemiesKilledToSpawn && !started)
        {
            started = true;
            InvokeRepeating("SpawnRandomEnemy", timeBetweenSpawn, timeBetweenSpawn);

        }
    }

    void SpawnRandomEnemy()
    {
        if (GameManager.Instance.currentEnemies < GameManager.Instance.enemiesperWave)
        {
            GameManager.Instance.currentEnemies += 1;

            int r = Random.Range(0, enemies.Length);
            Instantiate(enemies[r], transform.position, Quaternion.identity);
        }
    }
}
