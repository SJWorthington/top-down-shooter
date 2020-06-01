using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour {

    public static EnemyPooler instance { get; private set; }
    [SerializeField] private List<EnemyPool> poolsList;
    private Dictionary<EnemyType, EnemyPool> poolDictionary;
    [SerializeField]
    private EnemyFactory enemyFactory;

    [System.Serializable]
    private class EnemyPool : GenericPool<EnemyType> { /* Hello poppet */ }

    private void Awake() {
        instance = this;
    }

    void Start() {
        poolDictionary = new Dictionary<EnemyType, EnemyPool>();
        Debug.Log("poolsList size is " + poolsList.Count);
        foreach (EnemyPool pool in poolsList) {
            Debug.Log("Enemy pool created; " + pool);
            pool.initialisePool(enemyFactory);
            poolDictionary.Add(pool.poolObjectType, pool);
        }
    }

    public GameObject GetEnemy(EnemyType enemyType) {
        var pool = poolDictionary[enemyType];
        return poolDictionary[enemyType].Get();
    }

    public void returnToPool(GameObject enemy, EnemyType enemyType) {
        enemy.SetActive(false);
        poolDictionary[enemyType].returnToQueue(enemy);
    }
}
