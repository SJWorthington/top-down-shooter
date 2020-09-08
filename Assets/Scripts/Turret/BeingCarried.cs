using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingCarried : IState {

    private readonly BasicTurret turret;
    private readonly GameObject carrier;

    public BeingCarried(BasicTurret turret) {
        this.turret = turret;
    }

    public void Tick() {
        //Do nothing while carried
    }

    public void OnEnter() {
        turret.Target = null;
        turret.gameObject.transform.parent = turret.carryingObject.transform;
    }

    public void OnExit() {
        turret.carryingObject = null;
        turret.gameObject.transform.parent = null;
    }
}
