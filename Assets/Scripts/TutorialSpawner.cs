using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy_1;

    [SerializeField]
    GameObject enemy_2;

    [SerializeField]
    GameObject enemy_3;

    bool oneCreated = false;
    bool twoCreated = false;
    bool threeCreated = false;

    void Start()
    {
        SpawnEnemy1();
    }

    private void Update()
    {
        Invoke("CheckSpawner", 5);
    }

    void CheckSpawner()
    {
        if (!twoCreated)
            Invoke("SpawnEnemy2", 3);

        if (!threeCreated)
            Invoke("SpawnEnemy3", 8);
    }

    void SpawnEnemy1()
    {
        if (!oneCreated)
        {
            Instantiate(enemy_1, transform.position, Quaternion.identity);
            oneCreated = true;
        }
    }
    void SpawnEnemy2()
    {
        if (!twoCreated)
        {
            Instantiate(enemy_2, transform.position, Quaternion.identity);
            twoCreated = true;
        }
    }

    void SpawnEnemy3()
    {
        if (!threeCreated)
        {
            Instantiate(enemy_3, transform.position, Quaternion.identity);
            threeCreated = true;
        } 
    }
}
