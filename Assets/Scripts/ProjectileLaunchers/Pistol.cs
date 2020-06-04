using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : ProjectileLauncher
{
    public override void fire(float aimAngle) {
        var bullet = ProjectilePooler.instance.GetProjectile(ProjectileType.StandardBullet);
        bullet.SetActive(true);
        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
        bullet.transform.position = this.transform.position;
        bullet.GetComponent<StandardBullet>().fire(aimDirection, launchForce);
    }

    public override void reload() {
        throw new System.NotImplementedException();
    }
}
