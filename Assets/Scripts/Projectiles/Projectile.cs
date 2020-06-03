using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float maxLifetime;
    [SerializeField] protected Rigidbody2D rigidBody2D;

    public virtual void fire(Vector2 direction, int force) {
        rigidBody2D.AddForce(direction * force);
        Invoke("returnToPool", maxLifetime);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("BulletBarrier")) {
            returnToPool();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        returnToPool();
    }

    protected abstract void returnToPool();
}
