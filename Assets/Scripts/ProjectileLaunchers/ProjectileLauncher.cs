using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileLauncher : MonoBehaviour {
    [Header("Default attributes")]
    [SerializeField] protected int launchForce;
    [SerializeField] protected float coolDownTime;
    protected float coolDownTimer;

    //Could look at just passing in the aimAngle and calculating direction on fire
    //Will save me doing the aimDirection maths every update call
    public abstract void fire(float aimAngle);
    public abstract void reload();

    private void Start() {
        coolDownTimer = coolDownTime;
    }

    protected virtual void Update() {
        //This means every gun will count down even when not equipped, not great
        if (coolDownTimer < coolDownTime) {
            coolDownTimer += Time.deltaTime;
        }
    }

    public void setParentTransform(Transform parent) {
        this.transform.parent = parent;
    }
}
