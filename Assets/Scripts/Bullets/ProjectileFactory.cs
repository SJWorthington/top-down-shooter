using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : GenericTypeFactory<ProjectileType> {}

public enum ProjectileType { ShotgunPellet, StandardBullet }
