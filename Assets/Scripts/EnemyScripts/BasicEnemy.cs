using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy {
    [SerializeField] float moveSpeed;
    [SerializeField] float playerAggroRange = 10f;
    [SerializeField] float mainTargetAggroOverrideRange = 20f;

    private void Awake() {
        aiDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();
    }

    private void Update() {
        calculateTarget();
    }

    internal override void returnToPool() {
        EnemyPooler.instance.returnToPool(this.gameObject, EnemyType.Charger);
    }

    private void calculateTarget() {
        var distanceToTarget = Vector2.Distance(gameObject.transform.position, mainTargetTransform.position);
        var distanceToPlayer = Vector2.Distance(gameObject.transform.position, playerTransform.position);
        if (distanceToTarget > mainTargetAggroOverrideRange && CanSeePlayer(distanceToPlayer)) {
            aiDestinationSetter.target = playerTransform;
        } else {
            aiDestinationSetter.target = mainTargetTransform;
        }
    }

    private bool CanSeePlayer(float distanceToPlayer) {
        if (distanceToPlayer > playerAggroRange) return false;

        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerCoordinates, combinedMask);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player")) {
            return true;
        } else {
            return false;
        }
    }
}
