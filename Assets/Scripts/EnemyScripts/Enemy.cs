using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    //TODO - too much going on in here, this isn't using Entity-component well

    protected Vector2 playerCoordinates;
    [SerializeField] protected Rigidbody2D rigidBody;
    [SerializeField] protected int collisionDamageToPlayer;
    [SerializeField] protected int pointsOnDestroy;
    [SerializeField] List<string> destroyForScoreTags;
    internal Vector2 startPoint;

    // TODO - Suggests every enemy needs AIDestinationSetter, which is very limiting. Need a big old refactor
    protected Transform mainTargetTransform, playerTransform;
    protected AIDestinationSetter aiDestinationSetter;

    internal abstract void returnToPool();

    [SerializeField] List<LayerMask> rayCastLayerMaskList;
    internal LayerMask combinedMask;

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
        foreach (LayerMask layerMask in rayCastLayerMaskList) {
            int layer = (int)Mathf.Log(layerMask.value, 2);
            combinedMask |= 1 << layer;
        }
      
        PlayerMovement.OnPlayerVectorChanged += updatePlayerLocation;
        startPoint = gameObject.transform.position;
    }

    protected void updatePlayerLocation(Vector2 location) {
        playerCoordinates = location;
    }

    //TODO - use a C# property, this isn't Java
    public void setMainTransform(Transform mainTarget) {
        mainTargetTransform = mainTarget;
    }

    //TODO - use a C# property, this isn't Java
    public void setPlayerTransform(Transform playerTransform) {
        this.playerTransform = playerTransform;
    }
}
