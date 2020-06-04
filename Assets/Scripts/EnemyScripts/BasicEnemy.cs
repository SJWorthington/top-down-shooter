using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField] float moveSpeed;

    public override void Attack() {
        throw new System.NotImplementedException();
    }

    private void Update() {
        if (playerCoordinates != null) {
            Vector3 newLocation = Vector3.MoveTowards(rigidBody.position, playerCoordinates, moveSpeed * Time.deltaTime);
            rigidBody.MovePosition(newLocation);
        }
    }

    internal override void returnToPool() {
        EnemyPooler.instance.returnToPool(this.gameObject, EnemyType.LessBasic);
    }
}
