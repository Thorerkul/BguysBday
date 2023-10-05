using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatContoller : MonoBehaviour
{
    public int targetFPS = 60;

    public bool isInCombat;

    public bool isPlayerTurn;

    [Header("Camera")]
    [Range(0,1)]
    public float cameraSmooth;
    public Transform cameraCenter;
    public cameraScript cam;

    [Header("UI")]
    public Slider playerHealthSlider;
    public Slider playerHeliumSlider;
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

    public enemyScript[] enemies;
    public bool[] enemyTurn;
    public int currentEnemy;

    [Header("Timekeeping")]
    public float playerendturntime;
    public float playeranimationtime;

    public float enemyendturntime;
    public float enemyanimationtime;

    [Header("Sound")]
    public AudioClip battleMusic;
    public AudioClip fieldMusic;

    [Header("Other")]
    public GameObject battleUI;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }

    private void Update()
    {
        if (isInCombat)
        {
            CombatUpdate();
        } else
        {
            NormalUpdate();
        }

        battleUI.SetActive(isInCombat);
        player.isInCombat = isInCombat;
    }

    void NormalUpdate()
    {
        //cameraCenter.position = Vector3.Lerp(cameraCenter.position, player.transform.position, cameraSmooth);
    }

    void CombatUpdate()
    {
        playerHealthSlider.value = player.basis.health / player.basis.maxHealth;
        playerHeliumSlider.value = player.helium / player.maxHelium;
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
                if (isEnemyAttacking && !hasEnemyStartedAttacking){
                    enemyScript curEnemy = enemies[currentEnemy];
                    if (enemyTurn[currentEnemy])
                    {
                        if (curEnemy.currentAttack == AttackTypes.Basic)
                        {
                            curEnemy.attack(AttackTypes.Basic, player, curEnemy.basis.attackTypes[0].damage);
                            curEnemy.anim.SetTrigger("attack");
                            enemyendturntime = Time.timeSinceLevelLoad;
                            //hasEnemyStartedAttacking = true;
                        }
                        else if (curEnemy.currentAttack == AttackTypes.Heavy)
                        {
                            curEnemy.attack(AttackTypes.Heavy, player, curEnemy.basis.attackTypes[1].damage);
                            curEnemy.anim.SetTrigger("attack");
                            enemyendturntime = Time.timeSinceLevelLoad;
                            //hasEnemyStartedAttacking = true;
                        }
                        else
                        {
                            curEnemy.attack(AttackTypes.Basic, player, curEnemy.basis.attackTypes[0].damage);
                            curEnemy.anim.SetTrigger("attack");
                            enemyendturntime = Time.timeSinceLevelLoad;
                            //hasEnemyStartedAttacking = true;
                        }
                        enemyTurn[currentEnemy] = false;
                    }
                    else if (Time.timeSinceLevelLoad - enemyendturntime >= enemyanimationtime)
                    {
                        currentEnemy++;
                        if (currentEnemy <= enemyTurn.Length - 1)
                        {
                            enemyTurn[currentEnemy] = true;
                        }
                        else
                        {
                            isEnemyAttacking = false;
                            isPlayerTurn = true;
                            hasEnemyStartedAttacking = false;
                        }
                    }
                }
/*                if (isEnemyAttacking && hasEnemyStartedAttacking == false)
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
                } */
                /*if (Time.timeSinceLevelLoad - enemyendturntime >= enemyanimationtime)
                {
                    isEnemyAttacking = false;
                    isPlayerTurn = true;
                    hasEnemyStartedAttacking = false;
                }*/

                cameraCenter.position = Vector3.Lerp(cameraCenter.position, player.transform.position, cameraSmooth);
            } else
            {
                if (Time.timeSinceLevelLoad - playerendturntime >= playeranimationtime)
                {
                    isPlayerAttacking = false;
                    isEnemyAttacking = true;
                    enemyTurn[0] = true;
                    currentEnemy = 0;
                    foreach(enemyScript curEnemy in enemies)
                        curEnemy.currentAttack = curEnemy.basis.attackTypes[Random.Range(0, curEnemy.basis.attackTypes.Count)].type;
                }

                cameraCenter.position = Vector3.Lerp(cameraCenter.position, enemy.transform.position, cameraSmooth);
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
        else if (attack == "Heavy" && player.helium >= 5f)
        {
            player.currentAttack = AttackTypes.Heavy;
            player.anim.SetTrigger("HeavyAttack");
            player.attack(AttackTypes.Heavy, enemy, player.basis.attackTypes[1].damage);
        }
        else if (attack == "Piercing" && player.helium >= 5f)
        {
            player.currentAttack = AttackTypes.Piercing;
            player.anim.SetTrigger("PiercingAttack");
            player.attack(AttackTypes.Piercing, enemy, player.basis.attackTypes[2].damage);
        }
        else if (attack == "Blunt" && player.helium >= 5f)
        {
            player.currentAttack = AttackTypes.Blunt;
            player.anim.SetTrigger("BluntAttack");
            player.attack(AttackTypes.Blunt, enemy, player.basis.attackTypes[3].damage);
        }
        else{
            return;
        }

        isPlayerAttacking = true;
        isPlayerTurn = false;
        enemy.currentAttack = enemy.basis.attackTypes[Random.Range(0, enemy.basis.attackTypes.Count)].type;
        playerendturntime = Time.timeSinceLevelLoad;
    }
}
