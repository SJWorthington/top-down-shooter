using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] ProjectileLauncher turretGun;
    [SerializeField] float shotFrequency;
    [SerializeField] float range = 20f;
    private GameObject currentTarget = null;

    // Start is called before the first frame update
    void Start() {
        turretGun.setParentTransform(this.transform);
        InvokeRepeating("updateEnemy", 0f, 0.1f);
        InvokeRepeating("shootEnemy", 0f, shotFrequency);
    }

    void updateEnemy() {
        Debug.Log("Updating list of enemies");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log($"Number of enemies found {enemies.Length}");

        if (enemies.Length == 0) {
            Debug.Log($"No enemies apparently");
            currentTarget = null;
            return;
        } else if (currentTarget == null) {
            currentTarget = enemies[0];
        }

        foreach (GameObject enemy in enemies) {
            if (DistanceToEnemy(enemy) < DistanceToEnemy(currentTarget) || !currentTarget.gameObject.activeInHierarchy) {
                Debug.Log("New enemy targeted");
                currentTarget = enemy;
            }
        }
    }

    void shootEnemy() {
        
        //TODO - could use raycasting to only shoot if enemy is visible to turret, save shooting at walls
        if (currentTarget.gameObject.activeInHierarchy && DistanceToEnemy(currentTarget) < range) {
            //current target could be null, updating target and shooting separately is dangerous
            fireBullet(currentTarget.transform.position);
        }
    }

    float DistanceToEnemy(GameObject enemy) {
        return Vector2.Distance(transform.position, enemy.transform.position);
    }

    //TODO - don't think I'm using enemy position very efficiently
    void fireBullet(Vector2 target) {
        turretGun.fire(getAngleToEnemy(target));
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private float getAngleToEnemy(Vector2 enemyPosition) {

        var relativeVector = enemyPosition - (Vector2)this.transform.position;

        var angle = Mathf.Atan2(relativeVector.y, relativeVector.x);
        if (angle < 0f) {
            angle += Mathf.PI * 2;
        }
        return angle;
    }
}
