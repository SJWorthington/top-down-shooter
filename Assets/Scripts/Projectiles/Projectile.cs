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

    protected void OnCollisionEnter2D(Collision2D collision) {
        //TODO - this is too prescriptive, having to override this is bad
        returnToPool();
    }

    protected abstract void returnToPool();
}
