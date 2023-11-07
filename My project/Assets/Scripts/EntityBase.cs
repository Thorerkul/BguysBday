using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum AttackTypes
{
    None =    -1,
    Basic =    0,
    Heavy =    1,
    Blunt =    2,
}

[System.Serializable]
public class currentAttackTypes
{
    public string name;
    public int damage;
    public AttackTypes type;
}

public class EntityBase : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public AttackTypes immuneTo;

    [SerializeField]
    public List<currentAttackTypes> attackTypes;

    public void Die()
    {
        Destroy(gameObject);
    }
}
