using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBullet : Projectile {

    protected override void returnToPool() {
        ProjectilePooler.instance.returnToPool(this.gameObject, ProjectileType.StandardBullet); 
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //TODO - something with layermasks, not sure on those yet
    }
}
