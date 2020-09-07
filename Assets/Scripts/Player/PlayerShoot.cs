using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform reticule;

    public ProjectileLauncher projectileLauncher;
    public ProjectileLauncher secondProjectileLauncher;

    // Start is called before the first frame update
    void Start()
    {
        //TODO a more extensible way to set weapon's transforms when picked up
        if (projectileLauncher != null) {
            projectileLauncher.setParentTransform(this.transform);
        }
        if (secondProjectileLauncher != null) {
            secondProjectileLauncher.setParentTransform(this.transform);
        }
    }

    public void firePrimary(float aimAngle) {
        projectileLauncher.fire(aimAngle);
    }

    public void fireSecondary(float aimAngle) {
        secondProjectileLauncher.fire(aimAngle);
    }
}
