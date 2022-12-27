using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionForEnemy : MonoBehaviour
{
    public AttackingForDummies pf;
    public EnemyFollow ef;
    public EnemyBehaviour enemyBehaviour;
    // public CollisionDetection coldet;
    // private float deflectDelay = 1f;
    // private float lastDeflectTime = 0f;
    // private float cooldownTime = 0.5f;
    // private float lastInteractedTime = 0f;

    // GameObject Player1;
    // GameObject Enemy1;
    // void Start(){
    //     Player1 = GameObject.FindWithTag("Player");
    //     Enemy1 = GameObject.FindWithTag("Enemy");
    // }

    // void Update(){
    //     if(Time.time-lastDeflectTime > 1f){
    //         Player1.GetComponent<Animator>().speed = 1f;
    //         Enemy1.GetComponent<Animator>().speed = 1f;
    //     }
    // }

    private void OnTriggerEnter(Collider other){
        //if(Time.time - coldet.lastInteractedTime > 0.1f){
            if(other.tag== "Enemy" && pf.PlayerIsAttacking){
                if (GameManager.gameManager._enemyHealth.Health>0){
                    other.GetComponent<Animator>().SetInteger("HitOrDie", 1);
                }
                if (GameManager.gameManager._enemyHealth.Health<=0){
                    other.GetComponent<Animator>().SetInteger("HitOrDie", 2);
                }
                enemyBehaviour.PlayerTakeDmg(20);
                // coldet.lastInteractedTime = Time.time;
                //Debug.Log("Enemy Health: " + GameManager.gameManager._enemyHealth.Health);
            }
            // else if(other.tag== "Weapon" && pf.PlayerIsAttacking && ef.EnemyIsAttacking && Time.time - coldet.lastInteractedTime > 0.1f){
            //     Player1.GetComponent<Animator>().speed = 0f;
            //     Enemy1.GetComponent<Animator>().speed = 0f;
            //     lastDeflectTime = Time.time;
            //     Debug.Log("Swords Clashed");
            // }
        //}
    }
    private void OnTriggerExit(Collider other){
        if(other.tag== "Enemy"){
            other.GetComponent<Animator>().SetInteger("HitOrDie", 0);
        }
    }
}
