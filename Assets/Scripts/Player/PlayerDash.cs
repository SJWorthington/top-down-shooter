using System;
using UnityEngine;

public class PlayerDash : MonoBehaviour {

    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] int dashForce;
    [SerializeField] float dashCoolDown;
    [SerializeField] int invincibilityFrameCount;
    bool isCooling = false;
    private int invincibilityFramesRemaining;
    
    public void dash(Vector2 currentVelocity, float x, float y) {
        dashIsAvailable?.Invoke(false);
        invincibilityFramesRemaining = invincibilityFrameCount;
        hasDashInvincibility?.Invoke(true);
        Invoke("finishDashCooldown", dashCoolDown);
        var movementAngle = Mathf.Atan2(y, x);
        if (movementAngle < 0f) {
            movementAngle = Mathf.PI * 2 + movementAngle;
        }

        var dashDirection = Quaternion.Euler(0, 0, movementAngle * Mathf.Rad2Deg) * Vector2.right;

        rigidBody.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);
    }

    private void Update() {
        if (invincibilityFramesRemaining == 1) {
            invincibilityFramesRemaining--;
            hasDashInvincibility(false);
        } else if (invincibilityFramesRemaining > 1) {
            invincibilityFramesRemaining--;
        }
    }

    private void postDashInvincibilityFalse() {
        hasDashInvincibility?.Invoke(false);
    }

    private void finishDashCooldown() {
        dashIsAvailable?.Invoke(true);
    }

    public static event Action<bool> hasDashInvincibility;
    public static event Action<bool> dashIsAvailable;
}
