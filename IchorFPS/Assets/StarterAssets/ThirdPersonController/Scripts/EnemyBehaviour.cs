using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public void PlayerTakeDmg(int dmg){
        GameManager.gameManager._enemyHealth.DmgUnit(dmg);
    }

    public void PlayerHeal(int heal){
        GameManager.gameManager._enemyHealth.HealUnit(heal);
    }
}
