using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPellet : Projectile {

    protected override void returnToPool() {
        ProjectilePooler.instance.returnToPool(this.gameObject, ProjectileType.ShotgunPellet); 
    }
}
