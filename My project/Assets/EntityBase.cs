using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackTypes
{
    Basic =    1,
    Heavy =    5,
    Piercing = 3,
    Blunt =    2,
}

public class EntityBase : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float damage;
}
