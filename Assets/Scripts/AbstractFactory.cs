using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// I think we can do this better using generics, I don't like that my 
//projectile factory will return null for an enemy

    //Yeah this is gross, I am not going to use that book
public abstract class AbstractFactory : MonoBehaviour
{
    public abstract Projectile GetProjectile(ProjectileType projectileType);
    public abstract Enemy GetEnemy(EnemyType enemyType);
}
