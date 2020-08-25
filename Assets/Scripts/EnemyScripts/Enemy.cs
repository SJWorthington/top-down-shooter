using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    protected Vector2 playerCoordinates;
    [SerializeField] protected Rigidbody2D rigidBody;
    [SerializeField] protected int collisionDamageToPlayer;
    [SerializeField] protected int pointsOnDestroy;
    [SerializeField] List<string> destroyForScoreTags;

    public abstract void Attack();
    internal abstract void returnToPool();

    private void OnCollisionEnter2D(Collision2D collision) {
        var collisionTag = collision.gameObject.tag;
        if (collisionTag == "Player") {
            collision.gameObject.GetComponent<PlayerStatus>().damagePlayer(collisionDamageToPlayer);
            returnToPool();
        } else if (destroyForScoreTags.Contains(collisionTag)) { // This won't work for the enemy being destroyed by a dash attack
            ScoreController.GetInstance().addToPlayerScore(pointsOnDestroy);
            returnToPool();
        }
    }

    protected virtual void Start() {
        PlayerMovement.OnPlayerVectorChanged += updatePlayerLocation;
    }

    protected void updatePlayerLocation(Vector2 location) {
        playerCoordinates = location;
    }
}
