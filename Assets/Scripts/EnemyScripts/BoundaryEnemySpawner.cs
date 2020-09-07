using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryEnemySpawner : MonoBehaviour
{
    [SerializeField] private LevelBoundaryManager boundaryManager;
    private LevelBoundaryManager.LevelBoundaries bounds;

    // Start is called before the first frame update
    void Start()
    {
       bounds = boundaryManager.getLevelBoundaries();
       //InvokeRepeating("spawnEnemy", 0, 1f);
    }

    void spawnEnemy() {
        var randomInt = Random.Range(0, 100);
        GameObject enemy;
        if (randomInt < 50) {
            enemy = EnemyPooler.instance.GetEnemy(EnemyType.Crawler);
        } else {
            enemy = EnemyPooler.instance.GetEnemy(EnemyType.Charger);
        }

        var x = Random.Range(
            bounds.leftBound, 
            bounds.rightBound);
        var y = Random.Range(bounds.bottomBound, bounds.topBound);
        var spawnLocation = new Vector2(x, y);
        enemy.SetActive(true);
        enemy.transform.position = spawnLocation;
    }
}
