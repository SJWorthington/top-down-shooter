using System;
using UnityEngine;

public class PlayerDash : MonoBehaviour {

    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] int dashForce;
    [SerializeField] float dashCoolDown;
    [SerializeField] int invincibilityFrameCount;
    bool isCooling = false;
    private int invincibilityFramesRemaining;
    
    public void dash(float dashAngle) {
        if (isCooling) return;

        startDashCooldown();
        invincibilityFramesRemaining = invincibilityFrameCount;
        hasDashInvincibility?.Invoke(true);
        Invoke("finishDashCooldown", dashCoolDown);

        var dashDirection = Quaternion.Euler(0, 0, dashAngle * Mathf.Rad2Deg) * Vector2.right;

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

    //Could do this as a Property on isCooling instead
    private void startDashCooldown() {
        dashIsAvailable?.Invoke(false);
        isCooling = true;
    }

    private void finishDashCooldown() {
        dashIsAvailable?.Invoke(true);
        isCooling = false;
    }

    public static event Action<bool> hasDashInvincibility;
    public static event Action<bool> dashIsAvailable;
}
