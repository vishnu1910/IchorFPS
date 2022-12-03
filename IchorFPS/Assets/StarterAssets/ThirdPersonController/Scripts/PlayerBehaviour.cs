using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    // void Start()
    // {
        
    // }

    
    // void Update()
    // {
        
    // }

    public void PlayerTakeDmg(int dmg){
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    }

    public void PlayerHeal(int heal){
        GameManager.gameManager._playerHealth.HealUnit(heal);
    }
}
