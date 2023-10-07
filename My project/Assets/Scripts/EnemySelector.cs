using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelector : MonoBehaviour
{
    public int curEnemy = 0;
    public enemyScript[] enemies;
    enemyScript currentSelection;
    public playerScript player;

    float prevInput;

    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        if (player.currentEnemy == null)
            player.currentEnemy = enemies[curEnemy];
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Horizontal") != prevInput)
        {
            if (curEnemy - 1 < 0)
                curEnemy = enemies.Length;
            curEnemy -= 1;
            currentSelection = enemies[curEnemy];
            player.currentEnemy = currentSelection;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0.5f && Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Horizontal") != prevInput)
        {
            if (curEnemy + 1 >= enemies.Length)
                curEnemy = -1;
            curEnemy += 1;
            currentSelection = enemies[curEnemy];
            player.currentEnemy = currentSelection;
        }

        prevInput = Input.GetAxisRaw("Horizontal");
    }
}
