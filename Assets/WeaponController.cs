using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;
    public bool CanAttack= true;
    public float AttackCooldown = 1.0f;
    public AudioClip SwordAttackSound;
    public bool IsAttacking = false;
    public SFPSC_PlayerMovement pm;

    void Update(){
        if (Input.GetMouseButtonDown(0) && CanAttack && pm.isGrounded){
            SwordAttack();
        }
        else if(Input.GetMouseButtonDown(0) && CanAttack && !pm.isGrounded){
            JumpAttack();
        } 
    }

    public void SwordAttack(){
        IsAttacking = true;
        CanAttack =false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void JumpAttack(){
        IsAttacking = true;
        CanAttack =false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("JumpAttack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown(){
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool(){
        yield return new WaitForSeconds(1.0f);
        IsAttacking= false;
    }
}
