using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ProjectileLauncher {

    [Header("Shotgun attributes")]
    [SerializeField] int pelletCount;
    [SerializeField] float spreadInDegrees;
    [SerializeField] float forceVariance;

    private void Start() {
        setPelletCountOdd();
    }

    public override void fire( float aimAngle) {
        if (coolDownTimer < coolDownTime) return;
        coolDownTimer = 0;
        var halfPelletCount = pelletCount / 2;
        var pelletSpread = spreadInDegrees / pelletCount;
        for (int i = halfPelletCount; i > -halfPelletCount; i--) {
            var pellet = ProjectilePooler.instance.GetProjectile(ProjectileType.ShotgunPellet);
            pellet.SetActive(true);
            pellet.transform.position = this.transform.position;

            var aimAngleDegrees = aimAngle * Mathf.Rad2Deg;
            var pelletAngleDegrees = aimAngleDegrees + i * pelletSpread;
            if (pelletAngleDegrees > 360) {
                pelletAngleDegrees -= 360;
            } else if (pelletAngleDegrees < 0) {
                pelletAngleDegrees += 360;
            }

            var force = (int)Random.Range(launchForce - forceVariance, launchForce + forceVariance);
            var pelletSchmaimDirection = Quaternion.Euler(0, 0, pelletAngleDegrees) * Vector2.right;
            pellet.GetComponent<ShotgunPellet>().fire(pelletSchmaimDirection, force);
        }
    }

    private void setPelletCountOdd() {
        if (pelletCount % 2 == 0) {
            pelletCount += 1;
        }
    }

    public override void reload() {
        throw new System.NotImplementedException();
    }
}
