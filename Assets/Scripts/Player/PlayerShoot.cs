using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform reticule;

    private Vector2 playerPosition;

    public ProjectileLauncher projectileLauncher;
    public ProjectileLauncher secondProjectileLauncher;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;

        //TODO a more extensible way to set weapon's transforms when picked up
        if (projectileLauncher != null) {
            projectileLauncher.setParentTransform(this.transform);
        }
        if (secondProjectileLauncher != null) {
            secondProjectileLauncher.setParentTransform(this.transform);
        }
    }

    void Update()
    {
        var worldMousePosition =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        var facingDirection = worldMousePosition - transform.position;
        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);

        if (aimAngle < 0f) {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }

        playerPosition = transform.position;

        SetCrosshairPosition(aimAngle);

        if (Input.GetMouseButtonDown(0)) {
            secondProjectileLauncher.fire(aimAngle);
        }
        if (Input.GetMouseButtonDown(1)) {
            projectileLauncher.fire(aimAngle);
        }
    }



    private void SetCrosshairPosition(float aimAngle) {
        var x = transform.position.x + 1f * Mathf.Cos(aimAngle);
        var y = transform.position.y + 1f * Mathf.Sin(aimAngle);

        reticule.transform.position = new Vector3(x, y, 1);
    }
}
