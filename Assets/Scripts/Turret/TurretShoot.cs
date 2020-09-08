using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : IState {
    BasicTurret turret;
    readonly float shotFrequency;
    private float timeSinceShot;

    public TurretShoot(BasicTurret turret, float shotFrequency) {
        this.turret = turret;
        this.shotFrequency = shotFrequency;
    }

    public void Tick() {
        timeSinceShot += Time.deltaTime;
        if (timeSinceShot > shotFrequency) {
            timeSinceShot = 0;
            turret.fireAtTarget();
        }
    }

    public void OnEnter() { }

    public void OnExit() {
        turret.Target = null;
    }
}
