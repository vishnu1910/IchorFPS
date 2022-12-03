using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionForEnemy : MonoBehaviour
{
    public AttackingForDummies pf;
    public EnemyBehaviour enemyBehaviour;
    private void OnTriggerEnter(Collider other){
        if(other.tag== "Enemy" && pf.PlayerIsAttacking){
            if (GameManager.gameManager._enemyHealth.Health>0){
                other.GetComponent<Animator>().SetInteger("HitOrDie", 1);
            }
            if (GameManager.gameManager._enemyHealth.Health<=0){
                other.GetComponent<Animator>().SetInteger("HitOrDie", 2);
            }
            enemyBehaviour.PlayerTakeDmg(20);
            Debug.Log("Enemy Health: " + GameManager.gameManager._enemyHealth.Health);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.tag== "Enemy"){
            other.GetComponent<Animator>().SetInteger("HitOrDie", 0);
        }
    }
}
