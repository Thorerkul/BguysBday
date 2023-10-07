using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelector : MonoBehaviour
{
    int curEnemy = 0;
    public enemyScript[] enemies;
    enemyScript currentSelection;
    public playerScript player;
    void Update()
    {
        if (player.currentEnemy == null)
            player.currentEnemy = enemies[curEnemy];
        if (Input.GetKeyDown("a")){
            if (curEnemy - 1 < 0)
                curEnemy = enemies.Length;
            curEnemy -= 1;
            currentSelection = enemies[curEnemy];
            player.currentEnemy = currentSelection;
        }
        else if (Input.GetKeyDown("d")){
            if (curEnemy + 1 >= enemies.Length)
                curEnemy = -1;
            curEnemy += 1;
            currentSelection = enemies[curEnemy];
            player.currentEnemy = currentSelection;
        }
    }
}
