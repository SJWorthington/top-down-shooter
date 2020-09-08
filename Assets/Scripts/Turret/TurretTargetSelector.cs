using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretTargetSelector : IState
{
    //TODO - consistency with naming conventions
    private readonly BasicTurret _turret;
    private readonly float range;

    public bool HasEnemyTarget => targetEnemy != null && targetEnemy.gameObject.activeInHierarchy;

    private Enemy targetEnemy;

    public TurretTargetSelector(BasicTurret turret, float range) {
        _turret = turret;
        this.range = range;
    }

    public void Tick() {
        _turret.Target = selectNearestTarget();
    }

    private Enemy selectNearestTarget() {
        //TODO - this can absolutely be optimised
        List<Enemy> enemiesInRange = GameObject.FindObjectsOfType<Enemy>().ToList<Enemy>()
            .Where(enemy => Vector2.Distance(_turret.transform.position, enemy.transform.position) < range).ToList();

        if (enemiesInRange.Count == 0) {
            return null;
        } else {
            return enemiesInRange
                .OrderBy(enemy => Vector2.Distance(_turret.transform.position, enemy.transform.position))
                .FirstOrDefault();
        }
    }

    public void OnEnter() { }

    public void OnExit() { }
}
