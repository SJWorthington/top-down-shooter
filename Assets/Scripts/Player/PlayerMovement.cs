using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] PlayerDash playerDash;
    bool isDashAvailable = true;


    float xMovement = 0;
    float yMovement = 0;

    private Vector3 outVelocity;

    [SerializeField] private float moveSmoothing = 0.2f;

    private void Start() {
        PlayerDash.dashIsAvailable += setIsPlayerDashing;
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
        yMovement = Input.GetAxisRaw("Vertical") * moveSpeed;
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isDashAvailable && (xMovement != 0 || yMovement != 0)) {
                playerDash.dash(rigidBody.velocity, xMovement, yMovement);
            }
        }
    }

    private void FixedUpdate() {
        //Should I be creating a new Vector in every update? Is it better to update an existing one?
        Vector2 targetVelocity = new Vector2(xMovement, yMovement);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref outVelocity , moveSmoothing);
        OnPlayerVectorChanged?.Invoke(rigidBody.transform.position);
    }

    private void setIsPlayerDashing(bool isDashAvailable) {
        this.isDashAvailable = isDashAvailable;
    }

    public static event Action<Vector2> OnPlayerVectorChanged;
}
