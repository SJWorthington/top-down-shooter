using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private Color dashAvailableColor = new Color(0f, 255f, 255f);
    private Color dashUnavailableColor = new Color(200f, 200f, 200f);
    private Color dashInvincibilityColor = new Color(0f, 255f, 0f);

    void Start()
    {
        spriteRenderer.color = dashAvailableColor;
        PlayerDash.dashIsAvailable += setSpriteForDashCooldown;
        PlayerDash.hasDashInvincibility += setSpriteForInvincibility;
    }

    //This all needs restructured, setting yourself up for bugs here
    private void setSpriteForDashCooldown(bool dashIsAvailable) {
        if (dashIsAvailable) {
            spriteRenderer.color = dashAvailableColor;
        } else {
            spriteRenderer.color = dashUnavailableColor;
        }
    }

    private void setSpriteForInvincibility(bool isInvincible) {
        if (isInvincible) {
            spriteRenderer.color = dashInvincibilityColor;
        } else {
            spriteRenderer.color = dashUnavailableColor;
        }
    }
}
