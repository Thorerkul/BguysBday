using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public EntityBase basis;
    public AttackTypes currentAttack;

    public Animator anim;

    public void attack(AttackTypes type, playerScript enemy, float damage)
    {
        if (type != enemy.basis.immuneTo)
        {
            enemy.basis.health -= damage;
        }
    }
}
