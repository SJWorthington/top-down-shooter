using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReticuleController : MonoBehaviour
{
    [SerializeField] Transform reticuleTransform;

    public void SetAimAngle(float aimAngle) {
        var x = transform.position.x + 1f * Mathf.Cos(aimAngle);
        var y = transform.position.y + 1f * Mathf.Sin(aimAngle);

        reticuleTransform.position = new Vector3(x, y, 1);
    }
}
