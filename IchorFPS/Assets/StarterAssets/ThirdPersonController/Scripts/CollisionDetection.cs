using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public EnemyFollow ef;
    public PlayerBehaviour playerBehaviour;
    // private float cooldownTime = 0.5f;
    //public float lastInteractedTime = 0f;

    private void OnTriggerEnter(Collider other){
        //if(Time.time - lastInteractedTime > 0.1f){
            if(other.tag== "Player" && ef.EnemyIsAttacking){
                if (GameManager.gameManager._playerHealth.Health>0){
                    other.GetComponent<Animator>().SetInteger("HitOrDie", 1);
                }
                if (GameManager.gameManager._playerHealth.Health<=0){
                    other.GetComponent<Animator>().SetInteger("HitOrDie", 2);
                }
                playerBehaviour.PlayerTakeDmg(20);
                //Debug.Log("Enemy Health: " + GameManager.gameManager._enemyHealth.Health);
            }
            //lastInteractedTime = Time.time;
        //}
    }
    private void OnTriggerExit(Collider other){
        if(other.tag== "Player"){
            other.GetComponent<Animator>().SetInteger("HitOrDie", 0);
        }
    }
}
