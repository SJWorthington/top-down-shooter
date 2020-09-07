using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Crawler, Charger }

class EnemyFactory : GenericTypeFactory<EnemyType> {

    [SerializeField] Transform enemyTargetTransform;
    [SerializeField] Transform playerTransform;

    //override public GameObject GetNewInstance(EnemyType type) {
    //    var enemyObject = Instantiate(prefabDictionary[type]);

    //    var enemyPathfinding = enemyObject.GetComponent<AIDestinationSetter>();
    //    if (enemyPathfinding != null) {
    //        enemyPathfinding.target = playerTransform;
    //    }
    //    return enemyObject;
    //}

    override public GameObject GetNewInstance(EnemyType type) {
        var enemyObject = Instantiate(prefabDictionary[type]);

        var enemyScript = enemyObject.GetComponent<Enemy>();
        if (enemyScript != null) {
            enemyScript.setMainTransform(enemyTargetTransform);
            enemyScript.setPlayerTransform(playerTransform);
        }
        return enemyObject;
    }

}
