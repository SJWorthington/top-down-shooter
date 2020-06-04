using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    protected Vector2 playerCoordinates;
    [SerializeField] protected Rigidbody2D rigidBody;

    public abstract void Attack();
    internal abstract void returnToPool();

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Projectile")) {
            returnToPool();
        }
    }

    protected virtual void Start() {
        PlayerMovement.onPlayerVectorChanged += updatePlayerLocation;
    }

    protected void updatePlayerLocation(Vector2 location) {
        playerCoordinates = location;
    }
}
