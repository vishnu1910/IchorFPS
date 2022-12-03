using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public EnemyFollow ef;
    public PlayerBehaviour playerBehaviour;
    private void OnTriggerEnter(Collider other){
        if(other.tag== "Player" && ef.EnemyIsAttacking){
            if (GameManager.gameManager._playerHealth.Health>0){
                other.GetComponent<Animator>().SetInteger("HitOrDie", 1);
            }
            if (GameManager.gameManager._playerHealth.Health<=0){
                other.GetComponent<Animator>().SetInteger("HitOrDie", 2);
            }
            playerBehaviour.PlayerTakeDmg(20);
            Debug.Log("Player Health: " + GameManager.gameManager._playerHealth.Health);
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.tag== "Player"){
            other.GetComponent<Animator>().SetInteger("HitOrDie", 0);
        }
    }
}
