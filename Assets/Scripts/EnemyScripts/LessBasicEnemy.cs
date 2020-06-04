using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessBasicEnemy : Enemy {

    private int squaredAttackRange;
    [SerializeField] int attackRange;
    [SerializeField] int launchSpeed;
    [SerializeField] float chargeTime;
    [SerializeField] float chargeRotation;
    Vector2 previousPos;
    bool isCharging = false;

    protected override void Start() {
        base.Start();
        squaredAttackRange = attackRange * attackRange;
        previousPos = transform.position;
    }

    public override void Attack() {
        throw new System.NotImplementedException();
    }

    internal override void returnToPool() {
        EnemyPooler.instance.returnToPool(this.gameObject, EnemyType.LessBasic);
    }

    private void FixedUpdate() {
        var pos = (Vector2) transform.position;
        var isStationary = (pos == previousPos);
        if (isStationary && !isCharging && (pos - playerCoordinates).sqrMagnitude < squaredAttackRange) {
            isCharging = true;
            var vectorToFireOn = new Vector2(playerCoordinates.x, playerCoordinates.y);
            StartCoroutine("chargeForAttack", vectorToFireOn);
        }
        previousPos = transform.position;
    }

    private IEnumerator chargeForAttack(Vector2 position) {
        var chargeTimer = 0f;
        Vector3 rotation;
        while (chargeTimer < chargeTime) {
            if (transform.rotation.z < 0) {
                rotation = new Vector3(0, 0, chargeRotation);
            } else {
                rotation = new Vector3(0, 0, -chargeRotation * 3);
            }
            transform.Rotate(rotation);
            chargeTimer += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        chargeAtPosition(position);
    }

    private void chargeAtPosition(Vector2 position) {
        var fireDirection = position - (Vector2)transform.position;

        var angle = Mathf.Atan2(fireDirection.y, fireDirection.x);
        if (angle < 0f) {
            angle = Mathf.PI * 2 + angle;
        }

        var aimDirection = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg) * Vector2.right;

        rigidBody.AddForce(aimDirection * launchSpeed, ForceMode2D.Impulse);
        isCharging = false;
    }
}
