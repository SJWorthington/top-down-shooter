using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour {

    public static ProjectilePooler instance { get; private set; }
    [SerializeField] private List<ProjectilePool> poolsList;
    private Dictionary<ProjectileType, ProjectilePool> poolDictionary;
    [SerializeField]
    private ProjectileFactory factory;

    [System.Serializable]
    private class ProjectilePool : GenericPool<ProjectileType> { /* Hello poppet */ }

    private void Awake() {
        instance = this;
    }

    void Start() {
        poolDictionary = new Dictionary<ProjectileType, ProjectilePool>();
        foreach (ProjectilePool pool in poolsList) {
            pool.initialisePool(factory);
            poolDictionary.Add(pool.poolObjectType, pool);
        }
    }

    public GameObject GetProjectile(ProjectileType projectileType) {
        var pool = poolDictionary[projectileType];
        return poolDictionary[projectileType].Get();
    }

    public void returnToPool(GameObject projectile, ProjectileType projectileType) {
        projectile.SetActive(false);
        poolDictionary[projectileType].returnToQueue(projectile);
    }
}

