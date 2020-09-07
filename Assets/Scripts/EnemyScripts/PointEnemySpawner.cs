using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnemySpawner : MonoBehaviour
{
    private Vector2 spawnPoint;

    //I think spawnEnemy should be handled by an external spawn point controller that manages a list of these points
    [SerializeField] float spawnFrequency;

    // Start is called before the first frame update
    void Start() {
        spawnPoint = gameObject.transform.position;

        //Kill InvokeRepeating once I have spawnEnemy being called from SpawnPointController
        InvokeRepeating("spawnEnemy", 0, spawnFrequency);
    }

    //Enemy Type should be passed in here by the spawnPointController
    void spawnEnemy() {
        var randomInt = Random.value;
        GameObject enemy;
        if (randomInt < 2) {
            enemy = EnemyPooler.instance.GetEnemy(EnemyType.Crawler);
        } else {
            enemy = EnemyPooler.instance.GetEnemy(EnemyType.Charger);
        }

        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
