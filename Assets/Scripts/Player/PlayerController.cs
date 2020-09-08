using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerShoot playerShoot;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerReticuleController reticuleController;
    [SerializeField] PlayerDash playerDash;

    private Vector2 movementVector;

    private BasicTurret turretCarrying = null;
    private BasicTurret turretInRange = null;

    private float aimAngle;
    private float AimAngle {
        get { return aimAngle; }
        set {
            aimAngle = value;
            reticuleController.SetAimAngle(value);
        }
    }

    private void Awake() {
        movementVector = Vector2.zero;
        aimAngle = 0f;
    }

    public void OnShootPrimary(InputValue _) {
        playerShoot.firePrimary(aimAngle);
    }

    public void OnShootSecondary(InputValue value) {
        playerShoot.fireSecondary(aimAngle);
    }

    public void OnAim(InputValue value) {
        var aimVector = value.Get<Vector2>();
        AimAngle = angleFromVector(aimVector);
    }

    public void OnMovement(InputValue value) {
        movementVector = value.Get<Vector2>();
        playerMovement.setMovementVector(value.Get<Vector2>());
    }

    public void OnDash(InputValue value) {
        if (Mathf.Abs(movementVector.x) > float.Epsilon || Mathf.Abs(movementVector.y) > float.Epsilon) {
            var dashAngle = angleFromVector(movementVector);
            playerDash.dash(dashAngle);
        }
    }

    public void OnPickUpTurret(InputValue value) {
        if (turretCarrying != null) {
            turretCarrying.putDown();
            turretCarrying = null;
        } else if (turretInRange != null) {
            turretCarrying = turretInRange;
            turretInRange.pickUp(this.gameObject);
        }
    }

    private float angleFromVector(Vector2 vector) {
        var angle = Mathf.Atan2(vector.y, vector.x);
        if (angle < 0f) {
            angle += Mathf.PI * 2;
        }
        return angle;
    }

    //TODO - this is no good, but temporary
    //Should check collision type
    //Can also carry multiple turrets currently
    private void OnTriggerEnter2D(Collider2D collision) {
        turretInRange = collision.gameObject.GetComponent<BasicTurret>();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        turretInRange = null;
    }
}
