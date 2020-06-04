using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Dictionary<EnemyType, GameObject> enemyPrefabMap;

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("spawnicus", 0, 0.5f);
    }

    void spawnicus() {
        var randomInt = Random.Range(0, 100);
        GameObject enemy;
        if (randomInt < 50) {
            enemy = EnemyPooler.instance.GetEnemy(EnemyType.Basic);
        } else {
            enemy = EnemyPooler.instance.GetEnemy(EnemyType.LessBasic);
        }
        var x = Random.Range(-5, 5);
        var y = Random.Range(-5, 5);
        var locayCay = new Vector2(x, y);
        enemy.SetActive(true);
        enemy.transform.position = locayCay;
    }
}
