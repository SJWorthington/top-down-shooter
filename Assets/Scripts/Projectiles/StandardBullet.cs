using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : Projectile {

    protected override void returnToPool() {
        ProjectilePooler.instance.returnToPool(this.gameObject, ProjectileType.StandardBullet); 
    }
}
