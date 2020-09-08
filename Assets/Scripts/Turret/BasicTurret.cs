using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour {

    private StateMachine stateMachine;

    public Enemy Target { get; set; }
    
    public GameObject carryingObject { get; set; }

    [SerializeField] ProjectileLauncher turretGun;
    [SerializeField] float range;
    [SerializeField] float shotFrequency;

    private void Awake() {

        var targetSelection = new TurretTargetSelector(this, range);
        var turretShoot = new TurretShoot(this, shotFrequency);
        var beingCarried = new BeingCarried(this);

        stateMachine = new StateMachine();

        stateMachine.AddTransition(targetSelection, turretShoot, HasTarget());
        stateMachine.AddAnyTransition(targetSelection, IsReadyForTarget());
        stateMachine.AddAnyTransition(beingCarried, IsBeingCarried());

        stateMachine.SetState(targetSelection);

        Func<bool> HasTarget() => () => Target != null && Target.gameObject.activeInHierarchy;
        Func<bool> IsReadyForTarget() => () => (Target == null || !Target.gameObject.activeInHierarchy) && carryingObject == null; ;
        Func<bool> IsBeingCarried() => () => carryingObject != null; ;
    }

    void Update() => stateMachine.Tick();

    //TODO - might be nicer to put this into the shoot state, along with a reference to the gun.
    //Though then do we keep the target in there too? Maybe that gets messier
    public void fireAtTarget() {
        if (Target != null) {
            turretGun.fire(getAngleToEnemy());
        }
    }

    private float getAngleToEnemy() {

        var relativeVector = (Vector2)Target.gameObject.transform.position - (Vector2)turretGun.transform.position;

        var angle = Mathf.Atan2(relativeVector.y, relativeVector.x);
        if (angle < 0f) {
            angle += Mathf.PI * 2;
        }
        return angle;
    }

    public void pickUp(GameObject pickerUpper) {
        carryingObject = pickerUpper;
    }

    public void putDown() {
        carryingObject = null;
    }
}
