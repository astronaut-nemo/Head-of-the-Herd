using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Projectile", order = 1)]
public class ProjectileData : ScriptableObject
{
    public int damage;
    public float travelDistance;
    public int projectileNumber;
}
