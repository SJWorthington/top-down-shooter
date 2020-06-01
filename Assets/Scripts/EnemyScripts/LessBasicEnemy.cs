using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessBasicEnemy : Enemy {

    public override void Attack() {
        throw new System.NotImplementedException();
    }

    internal override void returnToPool() {
        EnemyPooler.instance.returnToPool(this.gameObject, EnemyType.LessBasic);
    }
}
