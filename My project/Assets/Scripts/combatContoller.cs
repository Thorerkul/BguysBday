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

            AnimatorStateInfo currentPlayerStateInfo = player.anim.GetCurrentAnimatorStateInfo(0);

            /*
            if (currentPlayerStateInfo.IsName("PlayerBasicAttack") || currentPlayerStateInfo.IsName("PlayerHeavyAttack") || currentPlayerStateInfo.IsName("PlayerPiercingAttack") || currentPlayerStateInfo.IsName("PlayerBluntAttack"))
            {
                isPlayerTurn = false;
            }*/

            cameraCenter.position = Vector3.Lerp(cameraCenter.position, player.transform.position, cameraSmooth);
        }
        else
        {
            attackHolder.SetActive(false);

            AnimatorStateInfo currentPlayerStateInfo = player.anim.GetCurrentAnimatorStateInfo(0);

            if (currentPlayerStateInfo.IsName("PlayerIdle"))
            {
                isPlayerAttacking = false;
            }

            if (!isPlayerAttacking)
            {
                cameraCenter.position = Vector3.Lerp(cameraCenter.position, enemy.transform.position, cameraSmooth);
            } else
            {
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
    }
}
