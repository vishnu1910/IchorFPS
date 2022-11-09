using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public AttackingForDummies pf;
    private void OnTriggerEnter(Collider other){
        if(other.tag== "Enemy" && pf.PlayerIsAttacking){
            // Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
    private void OnTriggerExit(Collider other){
        other.GetComponent<Animator>().ResetTrigger("Hit");
    }
}
