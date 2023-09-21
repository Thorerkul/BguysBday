using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatContoller : MonoBehaviour
{
    public Transform cameraCenter;
    public cameraScript cam;

    public bool isInCombat;

    public bool isPlayerTurn;

    [Header("Camera")]
    [Range(0,1)]
    public float cameraSmooth;

    [Header("UI")]
    public Slider playerHealthSlider;
    public Slider enemyHealthSlider;

    [Header("Combat")]
    public playerScript player;
    public bool isPlayerAttacking;

    public GameObject attackHolder;
    public Button UIbasicAttack;
    public Button UIheavyAttack;
    public Button UIpiercingAttack;
    public Button UIbluntAttack;

    public enemyScript enemy;
    public bool isEnemyAttacking;
    public bool hasEnemyStartedAttacking;

    [Header("Timekeeping")]
    public float playerendturntime;
    public float playeranimationtime;

    public float enemyendturntime;
    public float enemyanimationtime;

    [Header("Sound")]
    public AudioClip battleMusic;

    private void Update()
    {
        if (isInCombat)
        {
            CombatUpdate();
        }
    }

    void CombatUpdate()
    {
        playerHealthSlider.value = player.basis.health / player.basis.maxHealth;
        enemyHealthSlider.value = enemy.basis.health / enemy.basis.maxHealth;

        if (isPlayerTurn)
        {
            attackHolder.SetActive(true);

            cameraCenter.position = Vector3.Lerp(cameraCenter.position, player.transform.position, cameraSmooth);
        }
        else
        {
            attackHolder.SetActive(false);

            if (!isPlayerAttacking)
            {
                if (isEnemyAttacking && hasEnemyStartedAttacking == false)
                {
                    if (enemy.currentAttack == AttackTypes.Basic)
                    {
                        enemy.attack(AttackTypes.Basic, player, enemy.basis.attackTypes[0].damage);
                        enemy.anim.SetTrigger("attack");
                        enemyendturntime = Time.timeSinceLevelLoad;
                        hasEnemyStartedAttacking = true;
                    }
                    else if (enemy.currentAttack == AttackTypes.Heavy)
                    {
                        enemy.attack(AttackTypes.Heavy, player, enemy.basis.attackTypes[1].damage);
                        enemy.anim.SetTrigger("attack");
                        enemyendturntime = Time.timeSinceLevelLoad;
                        hasEnemyStartedAttacking = true;
                    }
                    else
                    {
                        enemy.attack(AttackTypes.Basic, player, enemy.basis.attackTypes[0].damage);
                        enemy.anim.SetTrigger("attack");
                        enemyendturntime = Time.timeSinceLevelLoad;
                        hasEnemyStartedAttacking = true;
                    }
                } 
                if (Time.timeSinceLevelLoad - enemyendturntime >= enemyanimationtime)
                {
                    isEnemyAttacking = false;
                    isPlayerTurn = true;
                    hasEnemyStartedAttacking = false;
                }

                cameraCenter.position = Vector3.Lerp(cameraCenter.position, enemy.transform.position, cameraSmooth);
            } else
            {
                if (Time.timeSinceLevelLoad - playerendturntime >= playeranimationtime)
                {
                    isPlayerAttacking = false;
                    isEnemyAttacking = true;
                    //enemy.currentAttack = enemy.basis.attackTypes[Random.Range(0, enemy.basis.attackTypes.Count)].type;
                }

                cameraCenter.position = Vector3.Lerp(cameraCenter.position, player.transform.position, cameraSmooth);
            }
        }
    }

    public void setAttack(string attack)
    {
        if (attack == "Basic")
        {
            player.currentAttack = AttackTypes.Basic;
            player.anim.SetTrigger("BasicAttack");
            player.attack(AttackTypes.Basic, enemy, player.basis.attackTypes[0].damage);
        } 
        else if (attack == "Heavy")
        {
            player.currentAttack = AttackTypes.Heavy;
            player.anim.SetTrigger("HeavyAttack");
            player.attack(AttackTypes.Heavy, enemy, player.basis.attackTypes[1].damage);
        }
        else if (attack == "Piercing")
        {
            player.currentAttack = AttackTypes.Piercing;
            player.anim.SetTrigger("PiercingAttack");
            player.attack(AttackTypes.Piercing, enemy, player.basis.attackTypes[2].damage);
        }
        else if (attack == "Blunt")
        {
            player.currentAttack = AttackTypes.Blunt;
            player.anim.SetTrigger("BluntAttack");
            player.attack(AttackTypes.Blunt, enemy, player.basis.attackTypes[3].damage);
        }

        isPlayerAttacking = true;
        isPlayerTurn = false;
        enemy.currentAttack = enemy.basis.attackTypes[Random.Range(0, enemy.basis.attackTypes.Count)].type;
        playerendturntime = Time.timeSinceLevelLoad;
    }
}
