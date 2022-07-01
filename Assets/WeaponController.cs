using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack= true;
    public float AttackCooldown = 1.0f;
    public AudioClip SwordAttackSound;
    void Update(){
        if (Input.GetMouseButtonDown(0) && CanAttack){
            SwordAttack();
        }
    }

    public void SwordAttack(){
        CanAttack =false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown(){
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }
}
