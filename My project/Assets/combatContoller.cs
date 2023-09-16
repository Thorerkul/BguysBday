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

    public GameObject attackHolder;
    public Button UIbasicAttack;
    public Button UIheavyAttack;
    public Button UIpiercingAttack;
    public Button UIbluntAttack;

    public enemyScript enemy;

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

            cameraCenter.position = Vector3.Lerp(cameraCenter.position, enemy.transform.position, cameraSmooth);
        }
    }
}
