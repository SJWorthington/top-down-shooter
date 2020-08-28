using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPellet : Projectile {

    [SerializeField] int maxBounceCount = 2;
    private int currentBounceCount = 0;

    protected override void returnToPool() {
        currentBounceCount = 0;
        ProjectilePooler.instance.returnToPool(this.gameObject, ProjectileType.ShotgunPellet); 
    }

    private new void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Enemy")) {
            returnToPool();
        } else {
            if (currentBounceCount == maxBounceCount) {
                returnToPool();
            } else {
                currentBounceCount++;
            }
        }
        //Do nothing because pellets bounce
    }
}
