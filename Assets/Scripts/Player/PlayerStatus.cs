using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    [SerializeField] int maxPlayerHealth;
    private int _currentPlayerHealth; // Need to get a better handle on using properties well
    private int currentPlayerHealth {
        get { return _currentPlayerHealth; }
        set {
            _currentPlayerHealth = value;
            onHealthChanged(value);
        }
    }
    private bool isInvulnerable;

    // Start is called before the first frame update
    void Start() {
        PlayerDash.hasDashInvincibility += setIsInvulnerable;
        currentPlayerHealth = maxPlayerHealth;
    }

    private void setIsInvulnerable(bool isInvulnerable) {
        this.isInvulnerable = isInvulnerable;
    }

    public void damagePlayer(int damage) {
        if (isInvulnerable) return;
        currentPlayerHealth = Mathf.Clamp(currentPlayerHealth - damage, 0, maxPlayerHealth);
    }

    public void healPlayer(int heals) {
        currentPlayerHealth = Mathf.Clamp(currentPlayerHealth + heals, 0, maxPlayerHealth);
    }

    public static event Action<int> onHealthChanged;
}
