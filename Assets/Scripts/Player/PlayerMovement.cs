using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] PlayerDash playerDash;

    Vector2 movementVector;

    private Vector3 outVelocity;

    [SerializeField] private float moveSmoothing = 0.5f;

    private void Awake() {
        movementVector = Vector2.zero;
    }

    private void FixedUpdate() {
        //Should I be creating a new Vector in every update? Is it better to update an existing one?
        Vector2 targetVelocity = movementVector * moveSpeed;
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref outVelocity, moveSmoothing);
        OnPlayerVectorChanged?.Invoke(rigidBody.transform.position);
    }

    public void setMovementVector(Vector2 movementVector) {
        this.movementVector = movementVector;
    }

    public static event Action<Vector2> OnPlayerVectorChanged;
}
