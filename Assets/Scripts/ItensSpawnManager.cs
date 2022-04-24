using UnityEngine;

public class ItensSpawnManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] enemies;

    [SerializeField]
    Transform[] places;

    [SerializeField]
    float timeBetweenSpawn = 5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", timeBetweenSpawn, timeBetweenSpawn);
    }

    void SpawnRandomEnemy()
    {
        int e = Random.Range(0, enemies.Length);
        int p = Random.Range(0, places.Length);

        Instantiate(enemies[e], places[p].position, Quaternion.identity);
    }
}
